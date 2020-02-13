using CCWin;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.Device;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;

using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel;

using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;

using System.Threading;

using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork
{
    partial class Home
    {
        /// <summary>
        /// 查询所有设备信息
        /// </summary>
        public void GetVeiveInfo()
        {


            if (ConfigHelper.KtpUploadNetWork)
            {
                try
                {
                    IMulePusher PanelLibrarySet = new WorkerAllGet() { RequestParam = new { id = ConfigHelper.KtpLoginProjectId } };

                    PushSummary pushSummary = PanelLibrarySet.Push();
                    if (!pushSummary.Success)
                    {
                        MessageHelper.Show(pushSummary.Message);
                        Application.Exit();
                        return;

                    }
                    WorkerAllResult rr = pushSummary.ResponseData;
                    label_proCount.Text = rr.data.certTotal.ToString();
                    lalUnCertTotalProCount.Text = rr.data.unCertTotal.ToString();
                    lab_sumCount.Text = rr.data.perTotal.ToString();
                    IMulePusher pusher = new DeviceGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                    PushSummary push = pusher.Push();
                    if (push.Success)
                    {

                        dataGridView_deviceList.DataSource = push.ResponseData;


                        dataGridView_deviceList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView_deviceList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        DataGridViewRowCollection dataGridView = dataGridView_deviceList.Rows;
                        dataCount = dataGridView.Count;
                        if (dataCount > 0)
                        {
                            //通过线程读取ip是否连接
                            for (int i = 0; i < dataGridView.Count; i++)
                            {

                                DataGridViewRow dgr = dataGridView_deviceList.Rows[i];

                                Thread t = new Thread(new ParameterizedThreadStart(Myping));
                                //t.Priority = ThreadPriority.Highest;
                                t.IsBackground = true; //关闭窗体继续执行
                                t.Start(dgr);

                            }
                        }
                        else
                        {

                            homeform.Enabled = true;
                            LoadingHelper.CloseForm();//关闭

                        }
                    }
                    else
                    {


                        MessageHelper.Show(push.Message);
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
                pl_ts.Visible = true;
                panel1.Visible = false;
                btnSyn_ktp.Enabled = false;
                LoadingHelper.CloseForm();//关闭
                ProjectInfo projectInfo = DataAddorRead.Park.projectInfo;
                if (projectInfo.projectId == 0 || projectInfo.projectName == "")
                {

                    new SetProjectForm().ShowDialog();
                    homeform.Enabled = true;
                    this.Text = $"建行开太平【{ConfigHelper.KtpLoginProjectName}】";
                    lab_projoectName.Text = ConfigHelper.KtpLoginProjectName;
                    label_proId.Text = ConfigHelper.KtpLoginProjectId.ToString();
                    new TeamInfo().AddDefult();
                }
                else
                {
                    homeform.Enabled = true;
                    ConfigHelper._KtpLoginProjectId = projectInfo.projectId;
                    ConfigHelper._KtpLoginProjectName = projectInfo.projectName;
                    this.Text = $"建行开太平【{ConfigHelper.KtpLoginProjectName}】";
                    lab_projoectName.Text = ConfigHelper.KtpLoginProjectName;
                    label_proId.Text = ConfigHelper.KtpLoginProjectId.ToString();

                }
                var worker = new WorkerInfo().GetList();
                label_proCount.Text = worker.Where(a => a.certificationStatus == 2).Count().ToString();
                lalUnCertTotalProCount.Text = worker.Where(a => a.certificationStatus == 1).Count().ToString();
                lab_sumCount.Text = worker.Count().ToString();

            }

        }

      
    }
}
