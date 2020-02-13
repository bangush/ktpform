using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel
{
    public class WorkerInfo
    {

        List<Workers> listWorers = DataAddorRead.Park.workers;
        /// <summary>
        /// 查询工人信息
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">一页显示的数量</param>
        /// <param name="teamId">班组id</param>
        /// <param name="keywords">模糊查询</param>
        /// <param name="state">认证状态</param>
        /// <returns></returns>
        public PagedResult<WokersList> GetPaged(int pageIndex, int pageSize, string teamId, string keywords, WorkerAuthenticationState state)
        {
            try
            {
                List<Workers> listSum = GetList();
                //var searchCriteria = new SearchCriteria<Workers>();
                //searchCriteria.PagingCriteria = new PagingCriteria(pageIndex, pageSize);
                //list.SearchBy(searchCriteria);
                if (state == WorkerAuthenticationState.Already)
                {//已认证状态
                    listSum = listSum.Where(a => a.certificationStatus == 2).ToList();
                }
                else if (state == WorkerAuthenticationState.WaitFor)
                {//待认证
                    listSum = listSum.Where(a => a.certificationStatus == 1).ToList();
                }
                else if (state == WorkerAuthenticationState.Delete)
                {//查询删除数据
                    listSum = GetList(true);
                }

                if (!string.IsNullOrEmpty(keywords))
                {   //搜索条件
                    listSum = listSum.Where<Workers>(c => c.poName.Contains(keywords)
                    || c.urealname.Contains(keywords) || c.uname.Contains(keywords) || c.usfz.Contains(keywords)).ToList();
                }

                if (!string.IsNullOrEmpty(teamId))
                {  //班组查询
                    listSum = listSum.Where(a => a.poId == FormatHelper.StringToInt(teamId)).ToList();
                }
                //分页
                var list = listSum.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderByDescending(a=>a.createTime).ToList();

                List<WokersList> lists = list.Select(i => new WokersList
                {
                    address = i.usAddress,
                    userName = i.urealname,
                    identityNum = i.usfz,
                    phoneNum = i.uname,
                    sex = i.usex.ToString(),
                    nation = i.usNation,
                    teamName = i.poName,
                    certificationStatus = FormatHelper.GetToString(i.certificationStatus),
                    teamId = FormatHelper.GetToString(i.localTeamId),
                    userId = FormatHelper.GetToString(i.localUserId),
                    ktpMag = i.ktpMag

                }).ToList();
                return new PagedResult<WokersList>(
      listSum.Count, lists);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog("本地查询工人列表:" + ex);
                throw;
            }

        }

        /// <summary>
        /// 根据用户id查询
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        public Workers GetWorker(int workerId)
        {
            List<Workers> list = GetList();
            return list.FirstOrDefault(a => a.localUserId == workerId);
        }
        /// <summary>
        /// 添加工人信息
        /// </summary>
        /// <param name="worker"></param>
        public string AddWorker(Workers worker)
        {
            try
            {
                List<Workers> list = GetList();
                if (list.Exists(a => a.usfz == worker.usfz))
                {
                    return "该用户已添加";
                }
                if (list.Exists(a => a.uname == worker.uname))
                {
                    Workers w = list.FirstOrDefault(a => a.uname == worker.uname);

                    return $"该用户添加的手机号已在【{w.urealname}】中工人存在";
                }
                int count = listWorers.Count + 1;
                worker.userId = count;
                worker.localUserId = count;
                listWorers.Add(worker);

               // DataAddorRead.Park.workers = listWorers;
                DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(" 本地添加工人信息:" + ex);
                return ex.Message;
            }
            return "";
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public string EditWorker(Workers worker)
        {

            try
            {
                List<Workers> list = GetList();

                if (list.Any(a => a.usfz == worker.usfz && a.localUserId != worker.localUserId))
                {
                    return "该用户已添加";
                }
                if (list.Any(a => a.uname == worker.uname && a.localUserId != worker.localUserId))
                {
                    Workers w = list.FirstOrDefault(a => a.uname == worker.uname);

                    return $"该用户添加的手机号在【{w.urealname}】中工人存在";
                }
               
                worker.updateTime = DateTime.Now;
                listWorers[worker.localUserId - 1] = worker;

                DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(" 本地编辑工人信息:" + ex);
                return ex.Message;

            }
            return "";
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public string RemoveWorker(int userId)
        {
            try
            {
                List<Workers> list = GetList();
                Workers w = list.FirstOrDefault(a => a.localUserId == userId);
                w.isDel = true;
                listWorers[w.localUserId - 1] = w;

                DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {

                LogHelper.ExceptionLog(" 本地删除数据工人信息:" + ex);
                return ex.Message;
            }
            return "";
        }
        /// <summary>
        /// 根据班组修改
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="teamName"></param>
        /// <returns></returns>
        public string SetTeamWorker(int teamId, string teamName)
        {

            try
            {
                List<Workers> listTeam = GetList().Where(a => a.localTeamId == teamId).ToList();
                foreach (var worker in listTeam)
                {

                    worker.poName = teamName;
                    worker.isSyn = false;
                    worker.updateTime = DateTime.Now;
                    listWorers[worker.localUserId - 1] = worker;

                }
                //DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {

                LogHelper.ExceptionLog(" 本地根据班组id修改工人信息:" + ex);
                DataAddorRead.SetDataInfo();
                return ex.Message;
            }
            return "";
        }
        /// <summary>
        ///查询本地数据
        /// </summary>
        /// <param name="isDel">是否删除</param>
        /// <returns>list</returns>
        public List<Workers> GetList(bool isDel = false)
        {
            List<Workers> workers = DataAddorRead.Park.workers;
            if (isDel)
            {
                return workers.Where(a => a.isDel == true && a.uproid==ConfigHelper.KtpLoginProjectId).ToList();
            }
            return workers.Where(a => a.isDel == false && a.uproid == ConfigHelper.KtpLoginProjectId).ToList();
        }
    }
}
