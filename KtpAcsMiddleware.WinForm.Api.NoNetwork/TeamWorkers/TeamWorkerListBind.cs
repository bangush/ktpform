using System;
using System.Drawing;
using System.Linq;

using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using System.Collections.Generic;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel;

namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    public partial class TeamWorkerList
    {

        public string _certificationStatus = null;
        /// <summary>
        ///班组列表绑定
        /// </summary>
        private void BindTeams(bool isKtp = true)
        {

            if (ConfigHelper.KtpUploadNetWork && isKtp)
            {
                GetKtpTeams();

            }
            else
            {

                //查询本地
                GetLocalTeams();
            }
        }

        private void GetKtpTeams()
        {
            try
            {
                TeamsLb.Items.Clear();
                TeamsLb.Items.Add("所有");
                IMulePusher pusher = new TeamGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                PushSummary push = pusher.Push();
                TeamResult r = push.ResponseData;
                _teams = r.data;



                if (_teams == null || _teams.Count == 0)
                    return;
                for (var i = 0; i < _teams.Count; i++)
                {
                    var team = _teams[i];
                    TeamsLb.Items.Add(team.organName);
                    if (!string.IsNullOrEmpty(_currentTeamId) && team.sectionId.ToString() == _currentTeamId)
                    {
                        TeamsLb.SelectedIndex = i + 1;
                    }
                }

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        //查询本地班组
        public void GetLocalTeams()
        {
            TeamsLb.Items.Clear();
            TeamsLb.Items.Add("所有");
            List<Team> list = new TeamInfo().GetTeams();

            _teams = list;

            if (_teams == null || _teams.Count == 0)
                return;
            for (var i = 0; i < _teams.Count; i++)
            {
                var team = _teams[i];
                TeamsLb.Items.Add(team.organName);
                if (!string.IsNullOrEmpty(_currentTeamId) && team.sectionId.ToString() == _currentTeamId)
                {
                    TeamsLb.SelectedIndex = i + 1;
                }
                if (string.IsNullOrEmpty(_currentTeamId))
                {
                    //_currentTeamId = _teams[0].Id;
                    TeamsLb.SelectedIndex = 0;
                }
            }

        }

        /// <summary>
        ///     分页控件翻页事件绑定
        /// </summary>
        private void InitGridPagingNavigatorControl()
        {
            WorkersGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        /// <summary>
        ///     分页控件翻页事件
        /// </summary>
        public void GridPagingNavigatorControlPagingEvent()
        {
            BindWorkers();
        }

        /// <summary>
        ///     工人列表绑定
        /// </summary>
        private void BindWorkers(string workerId = null, bool isKtp = true)
        {
            isKtp = _isKtp;
            if (ConfigHelper.KtpUploadNetWork && isKtp)
            {

                GetKtpWorkers();
            }
            else
            {

                //查询本地
                GetLocalWorkers();
            }
            if (isKtp)
            {
                WorkersGrid.Columns["ktpMag"].Visible = false;
            }
        }

        private void GetKtpWorkers()
        {
            try
            {

                var pageSize = WorkersGridPager.PageSize;
                var pageIndex = WorkersGridPager.PageIndex;


                int? teamId = null;
                int popState = 0;
                string certificationStatus = null;
                if (!string.IsNullOrEmpty(_currentTeamId))
                    teamId = FormatHelper.StringToInt(_currentTeamId);
                if (_certificationStatus == "4")
                {
                    popState = 4;
                    WorkerCms.Items[1].Visible = false;
                    WorkerCms.Items[2].Visible = false;
                }
                else
                if (!string.IsNullOrEmpty(_certificationStatus) && _certificationStatus != "0")
                    certificationStatus = _certificationStatus;
                else
                {
                    WorkerCms.Items[1].Visible = true;
                    WorkerCms.Items[2].Visible = true;
                }

                WorkerSend workerSend = new WorkerSend { certificationStatus = certificationStatus, teamId = teamId, projectId = ConfigHelper.KtpLoginProjectId, pageNum = pageIndex, pageSize = pageSize, keyWord = SearchText.Text.Trim(), popState = popState };
                IMulePusher pusher = new WokersGet() { RequestParam = workerSend };
                PushSummary push = pusher.Push();
                WorkersResult r = push.ResponseData;
                WorkersGridPager.PageCount = (r.data.total + pageSize - 1) / pageSize;

                WorkersGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                WorkersGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                List<WokersList> list = r.data.list.ToList();



                WorkersGrid.DataSource = list;

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void GetLocalWorkers(string workerId = null)
        {
            var pageSize = WorkersGridPager.PageSize;
            var pageIndex = WorkersGridPager.PageIndex;
            string teamId = null;
            WorkerInfo workerInfo = new WorkerInfo();
            if (!string.IsNullOrEmpty(_currentTeamId))
                teamId = _currentTeamId;

            PagedResult<WokersList> pagedTeamWorkers = workerInfo.GetPaged(pageIndex, pageSize, teamId, SearchText.Text.Trim(), (WorkerAuthenticationState)FormatHelper.StringToInt(_certificationStatus));
            WorkersGridPager.PageCount = (pagedTeamWorkers.Count + pageSize - 1) / pageSize;

            WorkersGrid.DataSource = pagedTeamWorkers.Entities.ToList();

          
        }

        /// <summary>
        ///     工人认证状态下拉框绑定
        /// </summary>
        private void BindWorkerAuthenticationStates()
        {
            var authenticationStates = WorkerAuthenticationState.All.GetDescriptions();
            WorkerAuthenticationStatesCb.DataSource = authenticationStates;
            WorkerAuthenticationStatesCb.DisplayMember = "Value";
            WorkerAuthenticationStatesCb.ValueMember = "Key";
            WorkerAuthenticationStatesCb.SelectedIndex = (int)WorkerAuthenticationState.All;
        }

        /// <summary>
        ///     初始化班组列表的右键项目
        /// </summary>
        private void InitTeamsCmsItemsVisible()
        {
            //班组右键选项

            if (ConfigHelper.KtpUploadNetWork)
            {

                TeamWorkerAddMenuItem.Visible = false;
                con_tems_add.Visible = false;
                exit_tems.Visible = false;
                WorkerSetForemanMenuItem.Visible = false;
            }

            //if (!string.IsNullOrEmpty(_currentTeamId))
            //{

            //    TeamWorkerAddMenuItem.Visible = true;

            //}


            //工人右键选项
            // InitWorkersCmsItemsVisible();
        }

        /// <summary>
        ///     初始化工人列表的右键项目
        /// </summary>
        private void InitWorkersCmsItemsVisible()
        {
            //WorkerAddMenuItem.Visible = false;
            //WorkerDetailMenuItem.Visible = false;
            WorkerEditMenuItem.Visible = false;

            WorkerDelMenuItem.Visible = false;


            if (WorkersGrid.CurrentRow != null && WorkersGrid.CurrentRow.Cells.Count > 0)
            {
                var currentWorkerId = WorkersGrid.CurrentRow.Cells[0].Value.ToString();
                //   currentWorker = _workers.FirstOrDefault(i => i.Id == currentWorkerId);
            }
            if (!string.IsNullOrEmpty(_currentTeamId))
            {
                //工人右键选项
                //WorkerAddMenuItem.Visible = true;
                //    if (currentWorker != null)
                //    {
                //        //非班组长的工人被选中时才显示：更换班组、设为班组长、删除
                //        //var selectWorkerAtTeam = _teams.First(i => i.Id == currentWorker.TeamId);
                //        //if (selectWorkerAtTeam.LeaderId != currentWorker.Id)
                //        //{


                //        //    WorkerDelMenuItem.Visible = true;
                //        //}
                //    }
                //}
                //if (currentWorker != null)
                //{
                //    // WorkerDetailMenuItem.Visible = true;
                //    WorkerEditMenuItem.Visible = true;
                //}
            }
        }
    }
}