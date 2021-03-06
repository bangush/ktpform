using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Api;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs
{
    /// <summary>
    ///     工人同步服务统一入口
    /// </summary>
    public class WorkerSyncAspService
    {
        private readonly WorkerIdentityAspService _ktpIdentityService;
        private readonly KtpWorkerLoadService _ktpWorkerLoadService;
        private readonly KtpWorkerUpService _ktpWorkerUpService;

        public WorkerSyncAspService()
        {
            _ktpWorkerLoadService = new KtpWorkerLoadService();
            _ktpWorkerUpService = new KtpWorkerUpService();
            _ktpIdentityService = new WorkerIdentityAspService();
        }

        /// <summary>
        ///     同步所有工人(忽略异常)
        /// </summary>
        public void SyncWorkersIgnoreEx(bool isLoadKtpData = false)
        {
            if (!isLoadKtpData)
            {
                isLoadKtpData = ConfigHelper.IsLoadKtpData;
            }
            PullIdentityCreditScore();
            LogHelper.Info(@"更新工人身份证信用分完成......");
            if (isLoadKtpData)
            {
                PullWorkersIgnoreEx();
                LogHelper.Info(@"从开太平同步工人完成......");
            }
            PushWorkersIgnoreEx();
            LogHelper.Info(@"添加(或编辑)工人同步完成......");
            PushDelWorkersIgnoreEx();
            LogHelper.Info(@"删除工人同步完成......");
        }

        /// <summary>
        ///     同步所有工人
        /// </summary>
        public void SyncWorkers(bool isLoadKtpData = false)
        {
            if (!isLoadKtpData)
            {
                isLoadKtpData = ConfigHelper.IsLoadKtpData;
            }
            PullIdentityCreditScore();
            if (isLoadKtpData)
            {
                PullWorkers();
            }
            PushWorkers();
            PushDelWorkers();
        }

        /// <summary>
        ///     拉取所有工人
        /// </summary>
        public void PullWorkers()
        {
            _ktpWorkerLoadService.PullWorkers();
        }

        /// <summary>
        ///     拉取所有工人(忽略异常)
        /// </summary>
        public void PullWorkersIgnoreEx()
        {
            try
            {
                _ktpWorkerLoadService.PullWorkers();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }

        /// <summary>
        ///     推送所有工人(忽略异常)
        /// </summary>
        public void PushWorkersIgnoreEx()
        {
            try
            {
                PushWorkers();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }

        /// <summary>
        ///     推送所有工人
        /// </summary>
        public void PushWorkers()
        {
            //同步所有工人照片到七牛
            UpWorkerNewPicsToQiniu();
            LogHelper.Info(@"同步工人照片到七牛完成......");

            var newWorkers = GetNewWorkers();
            if (newWorkers == null)
            {
                return;
            }
            LogHelper.Info($"PushWorkers newWorkers.Count={newWorkers.Count}");
            //获取所有(当前数据)文件的七牛数据
            var fileMapIds = newWorkers.Where(i => !string.IsNullOrEmpty(i.FacePicId))
                .Select(i => i.FacePicId).ToList();
            fileMapIds.AddRange(newWorkers.Where(i => !string.IsNullOrEmpty(i.Identity.PicId))
                .Select(i => i.Identity.PicId).ToList());
            fileMapIds.AddRange(newWorkers.Where(i => !string.IsNullOrEmpty(i.Identity.BackPicId))
                .Select(i => i.Identity.BackPicId).ToList());
            var qiniuFileCriteria = new SearchCriteria<FileMap>();
            qiniuFileCriteria.AddFilterCriteria(t => fileMapIds.ToArray().Contains(t.Id));
            qiniuFileCriteria.AddFilterCriteria(t => t.QiniuKey != null && t.QiniuKey != string.Empty &&
                                                     t.QiniuUrl != null && t.QiniuUrl != string.Empty);
            var qiniuFiles = DataFactory.FileMapRepository.Find(qiniuFileCriteria).ToList();
            //获取(当前数据)所有的班组同步信息
            var teamSyncs = DataFactory.TeamSyncRepository.FindAll();
            if (teamSyncs.Count == 0)
            {
                LogHelper.Info("PushWorkers teamSyncs.Count=0,return");
                return;
            }

            var erros = string.Empty;
            var newestId = string.Empty;
            var erroIds = string.Empty;
            foreach (var newWorker in newWorkers)
            {
                try
                {
                    var teamSync = teamSyncs.FirstOrDefault(i => i.Id == newWorker.TeamId);
                    if (teamSync == null)
                    {
                        continue;
                    }
                    //过滤同步错误的班组--ClientFactory.TeamSyncRepository.FindAll()已过滤
                    //if (teamSync.ThirdPartyId <= 0)
                    //{
                    //    continue;
                    //}
                    //人脸识别照片Url设置
                    var qiniuFacePic = qiniuFiles.FirstOrDefault(
                        i => !string.IsNullOrEmpty(newWorker.FacePicId) && i.Id == newWorker.FacePicId);
                    if (qiniuFacePic == null)
                    {
                        continue;
                    }
                    var qiniuFacePicUrl = qiniuFacePic.QiniuUrl;

                    //身份证正面照片Url设置
                    var qiniuIdentityPic = qiniuFiles.FirstOrDefault(
                        i => !string.IsNullOrEmpty(newWorker.Identity.PicId) && i.Id == newWorker.Identity.PicId);
                    if (qiniuIdentityPic == null)
                    {
                        continue;
                    }
                    var qiniuIdentityPicUrl = qiniuIdentityPic.QiniuUrl;
                    //身份证背面照片Url设置
                    var qiniuIdentityBackPic = qiniuFiles.FirstOrDefault(
                        i => !string.IsNullOrEmpty(newWorker.Identity.BackPicId) &&
                             i.Id == newWorker.Identity.BackPicId);
                    if (qiniuIdentityBackPic == null)
                    {
                        continue;
                    }
                    var qiniuIdentityBackPicUrl = qiniuIdentityBackPic.QiniuUrl;

                    //设置参数、执行推送
                    var parameters =
                        new KtpWorkerApiPushResultParameters
                        {
                            pro_id = ConfigHelper.ProjectId,
                            u_sfzpic = qiniuIdentityPicUrl,
                            u_sfz = newWorker.Identity.Code,
                            u_realname = newWorker.Identity.Name,
                            po_id = teamSync.ThirdPartyId,
                            u_name = newWorker.Mobile,
                            u_sex = newWorker.Identity.Sex == (int) WorkerSex.Man ? 1 : 2,
                            u_birthday = newWorker.Identity.Birthday,
                            u_cert_pic = qiniuFacePicUrl,
                            u_mz = ((IdentityNation) newWorker.Identity.Nation).ToEnumText()
                                .Replace("族", string.Empty),
                            //u_jiguan = newWorker.WorkerIdentity.Address,
                            u_address = newWorker.AddressNow,
                            u_sfz_zpic = qiniuIdentityPicUrl,
                            u_sfz_fpic = qiniuIdentityBackPicUrl,
                            u_start_time = newWorker.Identity.ActivateTime,
                            u_expire_time = newWorker.Identity.InvalidTime,
                            u_org = newWorker.Identity.IssuingAuthority
                        };
                    _ktpWorkerUpService.PushWorker(parameters, newWorker.Id);
                    newestId = newWorker.Id;
                }
                catch (Exception ex)
                {
                    erroIds = $"{erroIds}{newWorker.Id},";
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={newWorker.Id}|";
                }
            }
            if (erroIds != string.Empty)
            {
                erroIds = erroIds.TrimEnd('|');
            }
            //日志记录出现异常的工人ID以及最新同步成功的工人ID，本次同步成功的所有工人根据newestId从同步映射表中查询
            LogHelper.Info($"PushWorkers newestId={newestId},erroIds={erroIds}");
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }

        /// <summary>
        ///     推送所有删除的工人(忽略异常)
        /// </summary>
        public void PushDelWorkersIgnoreEx()
        {
            try
            {
                PushDelWorkers();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }

        /// <summary>
        ///     推送所有删除的工人
        /// </summary>
        public void PushDelWorkers()
        {
            var newDelWorkers = GetDelWorkers();
            if (newDelWorkers == null)
            {
                return;
            }
            LogHelper.Info($"PushDelWorkers newDelWorkers.Count={newDelWorkers.Count}");

            var erros = string.Empty;
            var newestId = string.Empty;
            var erroIds = string.Empty;
            foreach (var newDelWorker in newDelWorkers)
            {
                try
                {
                    _ktpWorkerUpService.PushDeleteWorker(newDelWorker.Id,
                        newDelWorker.Sync.TeamThirdPartyId, newDelWorker.Sync.ThirdPartyId);
                    newestId = newDelWorker.Id;
                }
                catch (Exception ex)
                {
                    erroIds = $"{erroIds}{newDelWorker.Id},";
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={newDelWorker.Id}|";
                }
            }
            if (erroIds != string.Empty)
            {
                erroIds = erroIds.TrimEnd('|');
            }
            //日志记录出现异常的工人ID以及最新同步成功的工人ID，本次同步(删除)成功的所有工人根据newestId从同步映射表中查询
            LogHelper.Info($"PushDelWorkers newestId={newestId},erroIds={erroIds}");
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }

        /// <summary>
        ///     拉取所有工人身份证信用分
        /// </summary>
        private void PullIdentityCreditScore()
        {
            var identitys = DataFactory.WorkerIdentityRepository.FindAll();
            if (identitys == null || identitys.Count == 0)
            {
                return;
            }
            foreach (var identity in identitys)
            {
                _ktpIdentityService.PullCreditScore(identity.Code);
            }
        }

        /// <summary>
        ///     上传工人图片到七牛
        /// </summary>
        public void UpWorkerNewPicsToQiniu()
        {
            var newQiniuFileMaps = DataFactory.FileMapRepository.FindWorkerNewPics();
            if (newQiniuFileMaps == null || newQiniuFileMaps.Count == 0)
            {
                return;
            }
            LogHelper.Info($"newQiniuFileMaps.Count={newQiniuFileMaps.Count}");
            foreach (var newQiniuFileMap in newQiniuFileMaps)
            {
                try
                {
                    var fileName = $"{ConfigHelper.CustomFilesDir}{newQiniuFileMap.PhysicalFileName}";
                    var qinieKey = QiniuHelper.UploadFile(fileName);
                    var qinieUrl = $"{QiniuHelper.QiniuBaseUrl}{qinieKey}";
                    DataFactory.FileMapRepository.ModifyQiniu(newQiniuFileMap.Id, qinieKey, qinieUrl);
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex,
                        $"UpWorkerNewPicsToQiniu foreach,newQiniuFileMap={newQiniuFileMap.ToJson()}");
                }
            }
        }


        /// <summary>
        /// 上传单个未上传工人图片到七牛
        /// </summary>
        public void UpWorkerNewPicsToQiniu(SearchCriteria<FileMap> searchCriteria)
        {
            var qiniuFiles = DataFactory.FileMapRepository.Find(searchCriteria).ToList();
            if (qiniuFiles == null || qiniuFiles.Count == 0)
            {
                return;
            }
            LogHelper.Info($"上传图片到七牛newQiniuFileMaps.Count={qiniuFiles.Count}");
            foreach (var newQiniuFileMap in qiniuFiles)
            {
                try
                {
                    var fileName = $"{ConfigHelper.CustomFilesDir}{newQiniuFileMap.PhysicalFileName}";
                    var qinieKey = QiniuHelper.UploadFile(fileName);
                    var qinieUrl = $"{QiniuHelper.QiniuBaseUrl}{qinieKey}";
                    DataFactory.FileMapRepository.ModifyQiniu(newQiniuFileMap.Id, qinieKey, qinieUrl);
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex,
                        $"上传图片到七牛出错:UpWorkerNewPicsToQiniu foreach,newQiniuFileMap={newQiniuFileMap.ToJson()}");
                }
            }
        }


        #region 获取需要同步的工人数据

        /// <summary>
        ///     获取需要同步的工人数据(PushWorkers)
        /// </summary>
        private IList<WorkerDto> GetNewWorkers()
        {
            var searchCriteria = new SearchCriteria<Worker>();
            //同步到开太平的数据必须时已经认证的工人
            searchCriteria.AddFilterCriteria(
                t => (t.WorkerSync == null
                      || t.WorkerSync.Status == (int) KtpSyncState.NewAdd
                      || t.WorkerSync.Status == (int) KtpSyncState.NewEdit)
                     && t.WorkerIdentity != null
                     && t.FacePicId != null && t.FacePicId != string.Empty
                     && t.WorkerIdentity.PicId != null && t.WorkerIdentity.PicId != string.Empty
                     && t.WorkerIdentity.BackPicId != null && t.WorkerIdentity.BackPicId != string.Empty);
            searchCriteria.AddFilterCriteria(t => t.Team != null && t.Team.TeamSync != null);
            var workers = DataFactory.WorkerQueryRepository.Find(searchCriteria);
            if (workers.Count == 0)
                return null;
            return workers;
        }

        /// <summary>
        ///     获取需要同步删除的工人数据(PushDelWorkers)
        /// </summary>
        private IList<WorkerDto> GetDelWorkers()
        {
            var searchCriteria = new SearchCriteria<Worker>();
            searchCriteria.AddFilterCriteria(t => t.WorkerSync != null &&
                                                  t.WorkerSync.Status == (int) KtpSyncState.NewDel);
            var workers = DataFactory.WorkerQueryRepository.Find(searchCriteria, true).ToList();
            if (workers.Count == 0)
                return null;
            return workers;
        }

        #endregion
    }
}