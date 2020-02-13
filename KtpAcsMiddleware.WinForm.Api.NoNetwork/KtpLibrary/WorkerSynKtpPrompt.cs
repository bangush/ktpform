using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel;
using KtpAcsMiddleware.WinForm.Api.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork.KtpLibrary
{
    public partial class WorkerSynKtpPrompt : FormBaseUi
    {
        private readonly Thread _workthread;
        public delegate void AddExceptionShow();
        //声明事件
        public event AddExceptionShow ShowSubmit;
        public WorkerSynKtpPrompt()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;


            _workthread = null;
            _workthread = new Thread(SyncWorkers) { IsBackground = true };
            _workthread.Start();
        }
        List<Workers> listWorers = DataAddorRead.Park.workers;
        List<Team> listTeam = DataAddorRead.Park.team;


        /// <summary>
        ///     同步(拉取/推送/双向同步)全部工人
        /// </summary>
        private void SyncWorkers()
        {
            try
            {

                SetSynLocalToKtp();
                closeOrder();
                if (WorkSysFail.list.Count() > 0)
                {

                    MessageHelper.Show("同步失败,请选择人重新编辑");
                    ShowSubmit();

                }
                else
                {


                    MessageHelper.Show("同步成功");


                }


            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);

                MessageHelper.Show(ex.Message);
            }
            finally
            {
                ControlBox = true;

            }
        }
        /// <summary>
        ///     窗口关闭事件
        /// </summary>
        private void WorkerSyncPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_workthread != null && _workthread.IsAlive)
                {
                    _workthread.Resume();
                    _workthread.Abort();
                }
            }
            catch
            {
                // ignored
            }
        }
        /// <summary>
        /// 关闭命令
        /// </summary>
        public void closeOrder()
        {
            if (this.InvokeRequired)
            {
                //这里利用委托进行窗体的操作，避免跨线程调用时抛异常，后面给出具体定义
                CONSTANTDEFINE.SetUISomeInfo UIinfo = new CONSTANTDEFINE.SetUISomeInfo(new Action(() =>
                {
                    while (!this.IsHandleCreated)
                    {
                        ;
                    }
                    if (this.IsDisposed)
                        return;
                    if (!this.IsDisposed)
                    {
                        this.Dispose();
                    }

                }));
                this.Invoke(UIinfo);
            }
            else
            {
                if (this.IsDisposed)
                    return;
                if (!this.IsDisposed)
                {
                    this.Dispose();
                }
            }
        }
        /// <summary>
        /// 同步ktp
        /// </summary>
        public void SetSynLocalToKtp()
        {
            var teamList = new TeamInfo().GetTeams();

            try
            {
                //上传班组到ktp返回班组id
                var list = teamList.Where(a => a.isSyn == false).ToList();

                foreach (var team in list)
                {
                    var time = team.createTime;
                    DataItem data = new DataItem
                    {
                        createTime = (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000 * 1000,
                        identityNum = team.identityNum,
                        organName = team.organName,
                        phoneNum = team.phoneNum,
                        sectionId = team.ktpTid == 0 ? null : team.ktpTid,
                        state = team.state,
                        teamWorkType = team.teamWorkType,
                        uproid = team.uproid,
                        userName = team.userName

                    };

                    IMulePusher pusher = new TeamSet() { RequestParam = data };
                    PushSummary push = pusher.Push();
                    if (push.Success)
                    {     //更新班组
                        TeamAddResult r = push.ResponseData;
                        var ktpId = r.data;
                        team.ktpTid = FormatHelper.StringToInt(ktpId);
                        team.isSyn = true;
                        listTeam[team.localId - 1] = team;
                    }
                    else
                    {


                    }

                }
                if (list.Count > 0)
                    DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {
                MessageHelper.Show(ex.Message);

                throw;
                ;
            }




            //同步成功的班组上传工人到ktp

            SynWorkerKtp();

        }

        private void SynWorkerKtp()
        {
            var ktpTeamList = new TeamInfo().GetTeams().Where(a => a.isSyn == true).ToList();
            foreach (var team in ktpTeamList)
            {

                List<Workers> listSum = new WorkerInfo().GetList().Where(a => a.localTeamId == team.localId && a.isSyn == false).ToList();

                if (listSum.Count > 0)
                {

                    foreach (var item in listSum)
                    {

                        item.ktpTid = team.ktpTid;
                        AddWorkerApi(item);
                    }
                }
            }
            //DataAddorRead.Park.workers = listWorers;
            //保存工人信息
            DataAddorRead.SetDataInfo();

        }

        private void AddWorkerApi(Workers workers)
        {


            try
            {
                string usfz = workers.usfz; string uPhone = workers.uname;
                IMulePusher phoneApi = new WorkerPhoneGet() { RequestParam = new { identityCard = usfz, phone = uPhone } };
                PushSummary pushSummary = phoneApi.Push();
                if (!pushSummary.Success)
                {
                    MessageHelper.Show(pushSummary.Message);
                    return;

                }
                Result result = pushSummary.ResponseData;

                //需要验证手机号
                if (result.data.verificationFlag)
                {

                    workers.ktpMag = "需要验证手机号";
                    AddSysFail(workers, "需要验证手机号");

                    return;
                }
                int? localId = workers.poId;
                int? localuserId = workers.userId;
                workers.poId = workers.ktpTid;
                workers.userId = workers.ktpUid;
                IMulePusher addworkers = new WorkerSet() { RequestParam = workers };
                PushSummary pushAddworkers = addworkers.Push();
                if (pushAddworkers.Success)
                {//上传工人成功
                    workers.poId = localId;
                    workers.userId = localuserId;
                    workers.isSyn = true;
                    workers.certificationStatus = 2;
                    listWorers[workers.localUserId - 1] = workers;
                }
                else
                {
                    workers.poId = localId;
                    workers.userId = localuserId;
                    workers.ktpMag = pushAddworkers.Message;
                    AddSysFail(workers, pushAddworkers.Message);
                }
                WorkSysFail.dicWorkadd.Clear();


            }
            catch (Exception ex)
            {
                MessageHelper.Show(ex.Message);

                throw;
            }
        }
        /// <summary>
        /// 添加到同步失败列表
        /// </summary>
        /// <param name="items">详情</param>
        /// <param name="mag">失败原因</param>
        public void AddSysFail(Workers items, string mag)
        {
            try
            {
                object isExit = null;
                if (string.IsNullOrEmpty(items.usfz) || string.IsNullOrEmpty(items.urealname))
                {

                }
                else
                {
                    isExit = WorkSysFail.list.FirstOrDefault(a => a.identityNum == items.usfz && a.userName == items.urealname);
                }

                if (isExit == null)
                {
                    WokersList wokersList = new WokersList
                    {
                        teamId = FormatHelper.GetToString(items.localTeamId),
                        identityNum = items.usfz,
                        sex = FormatHelper.GetToString(items.usex),
                        userId = FormatHelper.GetToString(items.userId),
                        userName = items.urealname,
                        teamName = items.poName,
                        phoneNum = items.uname,
                        reason = mag
                    };
                    WorkSysFail.list.Add(wokersList);
                }

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);

            }
        }
    }
}
