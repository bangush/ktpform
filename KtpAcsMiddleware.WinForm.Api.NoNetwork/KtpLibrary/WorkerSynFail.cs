using CCWin;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.KtpLibrary
{
    public partial class WorkerSynFail : Skin_Color
    {
        private bool _isKtp = true;
        public WorkerSynFail(bool isKtp = true)
        {
            _isKtp = isKtp;
            InitializeComponent();
            GetSysFail();
        }

        private void WorkerSynFail_Load(object sender, EventArgs e)
        {



        }

        public void GetSysFail()
        {



            this.skingrid_sysFail.AutoGenerateColumns = false;//不自动 
            BindingSource bingding = new BindingSource();
            bingding.DataSource = WorkSysFail.list;
            bingding.ResetBindings(true);
            bingding.CurrencyManager.Refresh();
            skingrid_sysFail.DataSource = null;
            skingrid_sysFail.DataSource = bingding;//绑定数据源 

            skingrid_sysFail.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            skingrid_sysFail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Team _teams = null;
            if (skingrid_sysFail.CurrentRow != null)
            {
                EeitFailWorker();
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }

        }

        private void skingrid_sysFail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int CIndex = e.ColumnIndex;
            string objectId = skingrid_sysFail["btnUpdate", e.RowIndex].Value.ToString(); // 获取所要修改关联对象的主键。
            if (CIndex == 8)
            {

                if (skingrid_sysFail.CurrentRow != null)
                {
                    EeitFailWorker();
                }
                else
                {
                    MessageHelper.Show("没有选中的工人");
                }
            }
        }

        private void EeitFailWorker()
        {
            var workerId = skingrid_sysFail.SelectedRows[0].Cells["userId"].Value.ToString();
            var teamId = skingrid_sysFail.SelectedRows[0].Cells["teamId"].Value;
            Team _teams = null;
            if (_isKtp)
            {
                IMulePusher pusher = new TeamGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                PushSummary push = pusher.Push();
                TeamResult r = push.ResponseData;
                _teams = r.data.Where(a => a.sectionId == Convert.ToInt32(teamId)).FirstOrDefault();
            }
            else
            {
                _teams = new TeamInfo().GetTeam(Convert.ToInt32(teamId));


            }
            if (_teams != null)
            {
                new AddWorkerInfo(FormatHelper.StringToInt(workerId), true, _teams.state, Convert.ToInt32(teamId), 0, true, _isKtp).ShowDialog();

            }
            else
            {
                MessageHelper.Show("班组不存在");
            }

            if (WorkSysFail.list.Count > 0)
            {

                GetSysFail();

            }
            else
            {
                MessageHelper.Show("同步成功");
                this.Close();
            }
        }
    }
}
