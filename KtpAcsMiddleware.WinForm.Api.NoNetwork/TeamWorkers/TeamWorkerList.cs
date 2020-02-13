using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService;
using CCWin;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.KtpLibrary;
using KtpAcsMiddleware.WinForm.Api.KtpLibrary;
using KtpAcsMiddleware.WinForm.Api.NoNetwork;

namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    public partial class TeamWorkerList : Skin_Color
    {
        private string _currentTeamId;
        private int isAdd;
        private bool _isKtp = true;
        private List<KtpApiService.TeamWorkers.Team> _teams;

        public TeamWorkerList()
        {
            InitializeComponent();
            WorkersGrid.AutoGenerateColumns = false;

            BindWorkerAuthenticationStates();
            InitGridPagingNavigatorControl();
            BindTeams();
            BindWorkers();
        }
        public TeamWorkerList(bool isKtpData)
        {
            InitializeComponent();
            this.Text = $"【{ConfigHelper.KtpLoginProjectName}】无网状态录入的工人数据";
            btnSyn_ktp.Visible = true;
            btn_project_id.Visible = true;
            WorkersGrid.AutoGenerateColumns = false;
            _isKtp = isKtpData;
            BindWorkerAuthenticationStates();
            InitGridPagingNavigatorControl();
            BindTeams(isKtpData);
            BindWorkers(null, isKtpData);
        }

        /// <summary>
        ///     窗口加载时
        /// </summary>
        private void TeamWorkerList_Load(object sender, EventArgs e)
        {

            InitTeamsCmsItemsVisible();
        }

        /// <summary>
        ///班组选中项改变
        /// </summary>
        private void TeamsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamsLb.SelectedItem == null)
            {
                return;
            }
            var teamName = TeamsLb.SelectedItem.ToString();
            var team = _teams.FirstOrDefault(i => i.organName == teamName);
            _currentTeamId = team == null ? string.Empty : team.sectionId.ToString();
            isAdd = team == null ? 0 : team.state;
            if (WorkerAuthenticationStatesCb.SelectedValue != null)
            {
                WorkersGridPager.PageIndex = 1;
            }
            InitTeamsCmsItemsVisible();

        }

        /// <summary>
        ///     班组列表右键-刷新
        /// </summary>
        private void TeamReloadMenuItem_Click(object sender, EventArgs e)
        {
            BindTeams();
            BindWorkers();
            MessageHelper.Show("班组列表已刷新");
        }

        /// <summary>
        ///     班组列表右键-班组编辑
        /// </summary>
        private void TeamEditMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }

            BindTeams();
            BindWorkers();
        }

        /// <summary>
        ///     班组列表右键-班组添加
        /// </summary>
        private void TeamAddMenuItem_Click(object sender, EventArgs e)
        {

            BindTeams();
            BindWorkers();
        }

        /// <summary>
        ///     班组列表右键-发工人添加
        /// </summary>
        private void TeamWorkerAddMenuItem_Click(object sender, EventArgs e)
        {

            string teamName = null;
            int type = 2;
            if (!string.IsNullOrEmpty(_currentTeamId))
            {
                Team team = new TeamInfo().GetTeam(Convert.ToInt32(_currentTeamId));
                if (team != null)
                {
                    teamName = team.organName;
                    type = team.state;
                }
                 

            }

            AddWorkerInfo worker = new AddWorkerInfo(type, true, teamName);
            worker.ShowDialog();
            BindWorkers();
        }

        /// <summary>
        ///     工人列表右键-工人编辑
        /// </summary>
        private void WorkerEditMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var teamId = WorkersGrid.SelectedRows[0].Cells[1].Value;
                var recordId = WorkersGrid.SelectedRows[0].Cells["recordId"].Value;
                KtpApiService.TeamWorkers.Team team = _teams.Where(a => a.sectionId == FormatHelper.StringToInt(teamId.ToString())).FirstOrDefault();
                bool isEdit = true;
                int state = 1;
                if (team != null)
                    state = team.state;
                new AddWorkerInfo(FormatHelper.StringToInt(workerId), isEdit, state, Convert.ToInt32(teamId), (int)recordId, false, _isKtp).ShowDialog();
                BindWorkers(workerId, _isKtp);
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人列表右键-工人删除
        /// </summary>
        private void WorkerDelMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                try
                {
                    var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                    var workerTeamId = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                    var workerName = FormatHelper.GetToString(WorkersGrid.SelectedRows[0].Cells[2].Value);
                    if (MessageBox.Show($@"确认要删除<{workerName}>吗？", @"删除提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        LoadingHelper.ShowLoadingScreen(LoadMagEnum.Delete);

                        if (ConfigHelper.KtpUploadNetWork && _isKtp)
                        {
                            WorkerDeleteSend send = new WorkerDeleteSend { projectId = ConfigHelper.KtpLoginProjectId, teamId = workerTeamId, userId = workerId };
                            IMulePusher wDeleteApi = new WorkerDelete() { RequestParam = send };

                            PushSummary pushSummary = wDeleteApi.Push();
                            WorkerDeleteResult workerDelete = pushSummary.ResponseData;

                            if (!workerDelete.success)
                            {
                                MessageHelper.Show($"<{workerName}>{workerDelete.msg}");
                                LogHelper.EntryLog(workerId, $"删除人员,id={workerId}");
                            }
                            else
                            {

                                MessageHelper.Show($"<{workerName}>删除成功");
                            }
                        }
                        else
                        {
                            string save = new WorkerInfo().RemoveWorker(FormatHelper.StringToInt(workerId));
                            if (save == "")
                            {
                                MessageHelper.Show($"<{workerName}>{save}");
                                LogHelper.EntryLog(workerId, $"删除人员,id={workerId}");
                            }
                            else
                            {

                                MessageHelper.Show($"<{workerName}>删除成功");
                            }
                        }
                        BindWorkers();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                    MessageHelper.Show(ex);
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人列表右键-工人添加
        /// </summary>
        private void WorkerAddMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }

            BindWorkers();
        }

        /// <summary>
        ///     工人列表右键-工人详情
        /// </summary>
        private void WorkerDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();

            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///工人列表右键-更换班组
        /// </summary>
        private void WorkerChangeTeamMenuItem_Click(object sender, EventArgs e)
        {
            //if (WorkersGrid.CurrentRow != null)
            //{
            //    var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
            //    var selectWorker = _workers.First(i => i.Id == workerId);
            //    var selectWorkerAtTeam = _teams.FirstOrDefault(i => i.Id == selectWorker.TeamId);
            //    if (selectWorkerAtTeam != null && selectWorkerAtTeam.LeaderId == workerId)
            //    {
            //        MessageHelper.Show("班组长不允许更换班组");
            //        return;
            //    }

            //    new WorkerChangeTeamDetailed(workerId, _currentTeamId).ShowDialog();
            //    BindWorkers();
            //}
            //else
            //{
            //    MessageHelper.Show("没有选中的工人");
            //}
        }




        /// <summary>
        ///     搜索按钮
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            WorkersGridPager.PageIndex = 1;

        }

        /// <summary>
        ///     工人列表选中项改变
        /// </summary>
        private void WorkersGrid_SelectionChanged(object sender, EventArgs e)
        {
            //  InitWorkersCmsItemsVisible();
        }

        private void TeamsCms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        private void WorkerAuthenticationStatesCb_SelectedValueChanged(object sender, EventArgs e)
        {
            _certificationStatus = WorkerAuthenticationStatesCb.SelectedValue.ToString();

            if (_certificationStatus != "KtpAcsMiddleware.Infrastructure.Utilities.DicKeyValueDto")
                BindWorkers();
            else
                _certificationStatus = null;
        }
        /// <summary>
        /// 查看菜单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerSeeMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var teamId = WorkersGrid.SelectedRows[0].Cells[1].Value;
                var recordId = WorkersGrid.SelectedRows[0].Cells["recordId"].Value;
                KtpApiService.TeamWorkers.Team team = _teams.Where(a => a.sectionId == FormatHelper.StringToInt(teamId.ToString())).FirstOrDefault();
                bool isEdit = false;
                new AddWorkerInfo(FormatHelper.StringToInt(workerId), isEdit, team.state, Convert.ToInt32(teamId), (int)recordId, false, _isKtp).ShowDialog();
                BindWorkers(workerId, _isKtp);
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            WorkersGridPager.PageIndex = 1;
        }

        private void con_tems_add_Click(object sender, EventArgs e)
        {

        }

        private void exit_tems_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            if (isAdd == 1)
            {
                MessageHelper.Show("只能选择班组修改");
                return;
            }
            new AddTeamInfo(FormatHelper.StringToInt(_currentTeamId)).ShowDialog();
            BindTeams();
            BindWorkers();
        }

        private void add_team_con(object sender, EventArgs e)
        {
            new AddTeamInfo().ShowDialog();
            BindTeams();
            BindWorkers();
        }

        private void WorkerSetForemanMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow == null)
            {
                MessageHelper.Show("没有选中的工人");
                return;
            }
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            try
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var teamId = WorkersGrid.SelectedRows[0].Cells[1].Value;
                var workerName = FormatHelper.GetToString(WorkersGrid.SelectedRows[0].Cells[2].Value);
                if (MessageBox.Show($@"确认要将<{workerName}>设为当前班组组长吗？", @"设置班组长提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mag = new TeamInfo().SetForeman(FormatHelper.StringToInt(workerId));
                    if (mag == "")
                        MessageHelper.Show($"<{workerName}>已被设为当前班组组长");
                    else
                        MessageHelper.Show(mag);
                    BindWorkers(workerId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void btnSyn_ktp_Click(object sender, EventArgs e)
        {
            ConfigHelper.IsApplicationUpload = true;
            //清空上次同步失败的人员
            WorkSysFail.list.Clear();
            WorkerSynKtpPrompt frm = new WorkerSynKtpPrompt();
            //注册事件
            frm.ShowSubmit += ShowExptForm;
            frm.ShowDialog();

        }
        public void ShowExptForm()
        {
            if (WorkSysFail.list.Count() > 0)
            {

                new WorkerSynFail(false).ShowDialog();
            }

        }

        private void btn_project_id_Click(object sender, EventArgs e)
        {
            new SetProjectForm(true).ShowDialog();
            BindTeams(false);
            BindWorkers();
        }
    }
}