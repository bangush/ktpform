using CCWin;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Device;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.Api.FaceRecognition;
using KtpAcsMiddleware.WinForm.Api.KtpLibrary;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.KtpLibrary;
using KtpAcsMiddleware.WinForm.Api.Shared;
using KtpAcsMiddleware.WinForm.Api.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.WorkerAuths;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelWorkerSend;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork
{


    public partial class Home : Skin_Color
    {
        public static Home homeform;
        static int isEnd = 0;
        static int dataCount = 0;
        public Home()
        {


            InitializeComponent();
            homeform = this;
            homeform.Enabled = false;
            WorkSysFail.workAdd.Clear();
            isEnd = 0;
            CheckForIllegalCrossThreadCalls = false;//干掉检测 不再检测跨线程
            LoadingHelper.ShowLoadingScreen();//显示

            //Thread childThread = new Thread(GetVeiveInfo);
            //childThread.Start();




        }

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Home_Deactivate(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //this.Close();
        }
        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_addDevice_Click(object sender, EventArgs e)
        {
            FaceDeviceDetail addForm = new FaceDeviceDetail();
            addForm.ShowDialog();
            GetVeiveInfo();//重新绑定


        }
        /// <summary>
        /// 新增人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorker_Click(object sender, EventArgs e)
        {
            AddWorkerInfo worker = new AddWorkerInfo(1);
            worker.ShowDialog();
            GetVeiveInfo();
        }




        private void Home_Load(object sender, EventArgs e)
        {
            this.Text = $"建行开太平【{ConfigHelper.KtpLoginProjectName}】";
            lab_projoectName.Text = ConfigHelper.KtpLoginProjectName;
            label_proId.Text = ConfigHelper.KtpLoginProjectId.ToString();

            bool IsManualAddInfo = FormatHelper.GetStringToBoolean(ConfigurationManager.AppSettings["IsManualAddInfo"]);
            if (IsManualAddInfo)
            {
                toolStripMenuItem1.CheckState = CheckState.Checked;
            }
            else
            {
                toolStripMenuItem1.CheckState = CheckState.Unchecked;
            }




            string hostName = Dns.GetHostName();//本机名              
            System.Net.IPAddress[] ipHost = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6 
            foreach (IPAddress ip in ipHost)

            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    labIp.Text = ip.ToString();
                }

            }

            if (ConfigHelper.IsDivceAdd)
            {
                con_isDivce.CheckState = CheckState.Checked;

                btnSyn.Enabled = true;
                button_addDevice.Enabled = true;

            }
            else
            {
                if (dataGridView_deviceList.RowCount < 1)
                {
                    btnSyn.Enabled = false;
                    button_addDevice.Enabled = false;
                }
                con_isDivce.CheckState = CheckState.Unchecked;
            }
            GetVeiveInfo();

        }

        private void button_viewDeviceUserInfo_Click(object sender, EventArgs e)
        {
            new TeamWorkerList().Show();
        }


        /// <summary>
        /// 右键编辑设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceEditMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridView_deviceList.CurrentRow != null)
            {
                //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                var DeviceId = dataGridView_deviceList.SelectedRows[0].Cells[1].Value.ToString();
                new FaceDeviceDetail(DeviceId).ShowDialog();
                GetVeiveInfo();//重新绑定

            }
            else
            {
                MessageHelper.Show("没有选中设备");
            }
        }



        private void DeviceDelMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridView_deviceList.CurrentRow != null)
            {
                try
                {
                    var DeviceId = dataGridView_deviceList.SelectedRows[0].Cells[1].Value;
                    var DeviceIp = dataGridView_deviceList.SelectedRows[0].Cells[3].Value;

                    if (MessageBox.Show($@"删除将清空人脸识别的人员,确认要删除<{DeviceIp}>吗？", @"删除提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        LoadingHelper.ShowLoadingScreen(LoadMagEnum.Delete);
                        IMulePusher wDeleteApi = new DeviceDelete() { RequestParam = new { proId = (int)ConfigHelper.KtpLoginProjectId, id = (int)DeviceId, ip = DeviceIp } };

                        PushSummary pushSummary = wDeleteApi.Push();
                        if (!pushSummary.Success)
                        {

                            MessageHelper.Show($"<{DeviceIp}>" + pushSummary.Message + "");
                            return;
                        }

                        DeviceDeleteResult rr = pushSummary.ResponseData;



                        if (rr.success)
                        {

                            MessageHelper.Show($"<{DeviceIp}>删除成功");
                            GetVeiveInfo();
                        }
                        else
                        {
                            MessageHelper.Show($"<{DeviceIp}>" + rr.msg + "");
                            LogHelper.EntryLog(DeviceId.ToString(), $"DelTeamWorker,id={DeviceId}");

                        }

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
                MessageHelper.Show("没有选中设备");
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddWorkerInfo worker = new AddWorkerInfo(2);
            worker.ShowDialog();
            GetVeiveInfo();

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }


        /// <summary>
        /// 同步云端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyn_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            int count = dataGridView_deviceList.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView_deviceList.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    string check_ip = this.dataGridView_deviceList.Rows[i].Cells[3].Value.ToString();
                    //string isConn = this.dataGridView_deviceList.Rows[i].Cells[7].Value.ToString();

                    if (ConfigHelper.MyPing(check_ip))
                    {
                        list.Add(check_ip);
                    }

                }
            }
            if (list.Count() < 1)
            {
                MessageHelper.Show("未选择同步的面板");
                return;
            }
            //清空上次同步失败的人员
            WorkSysFail.list.Clear();
            WorkerSyncPrompt frm = new WorkerSyncPrompt(list);
            //注册事件
            frm.ShowSubmit += ShowExptForm;
            frm.ShowDialog();


            GetVeiveInfo();


        }
        public void ShowExptForm()
        {
            if (WorkSysFail.list.Count() > 0)
            {

                new WorkerSynFail().ShowDialog();
            }

        }

        private void labIp_Click(object sender, EventArgs e)
        {

        }

        private void shuaxin_Click(object sender, EventArgs e)
        {
            WorkSysFail.workAdd.Clear();
            homeform.Enabled = false;
            isEnd = 0;
            LoadingHelper.ShowLoadingScreen();//显示
            GetVeiveInfo();

        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public static void Myping(dynamic dgr)
        {

            bool isConn = true;
            dynamic ip = dgr.Cells["deviceIp"].Value;
            dynamic deviceNo = dgr.Cells["machineNum"].Value;
            dynamic deviceIn = dgr.Cells["Title_direction"].Value;
            var workAdd = WorkSysFail.workAdd.FirstOrDefault(a => a.deviceIp == ip);
            if (workAdd != null)
            {
                isConn = workAdd.isConn;

            }
            else
            {

                //设备是否连接
                isConn = ConfigHelper.MyPing(ip);

                if (isConn)
                {
                    var okConnPanelInfo = new WorkAddInfo { deviceIp = ip, isConn = true, deviceIn = deviceIn, deviceNo = deviceNo, magAdd = "添加中.." };
                    WorkSysFail.workAdd.Add(okConnPanelInfo);

                }

                isEnd++;

            }
            dgr.Cells["Title_deviceStatus"].Value = isConn ? "是" : "否";
            if (isConn)
            {
                //返回设备的数量

                Liblist liblist = PanelBase.GetPanelDeviceInfo(ip);
                if (liblist != null)
                {

                    //设备数量

                    dgr.Cells["panelCount"].Value = liblist.MemberNum;
                }

            }
            if (dgr.Cells["Title_deviceStatus"].Value.ToString() == "否")//
            {


                dgr.Cells["Title_deviceStatus"].Style.ForeColor = Color.Red;//将前景色设置为红色，即字体颜色设置为红色

            }

            if (isEnd == dataCount)
            {
                homeform.Enabled = true;
                LoadingHelper.CloseForm();//关闭




            }


        }

        private void lalUnCertTotalProCount_Click(object sender, EventArgs e)
        {

        }

        private void btn_Auth_Click(object sender, EventArgs e)
        {
            new WorkerAuthList().Show();
        }
        /// <summary>
        /// 系统菜单-退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_application_Exit_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

        /// <summary>
        /// 系统菜单-打开日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_application_journal_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\logs";
            if (Directory.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                MessageHelper.Show("日志目录还未生成！");
        }

        private void menu_application_IsManualAddInfo_CheckStateChanged(object sender, EventArgs e)
        {
            CheckState check = con_isDivce.CheckState;
            if (check == CheckState.Checked)
                modifyItem("IsManualAddInfo", "True");
            else
                modifyItem("IsManualAddInfo", "False");
        }
        public void modifyItem(string keyName, string newKeyValue)
        {    //修改配置文件中键为keyName的项的值   

            //读取程序集的配置文件
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            string appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //获取appSettings节点
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");

            //删除name，然后添加新值
            appSettings.Settings.Remove(keyName);
            appSettings.Settings.Add(keyName, newKeyValue);
            //保存配置文件
            config.Save();
        }
        /// <summary>
        /// 是否有闸机菜单，true，有， false，无，第一次录入会记录考勤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void con_isDivce_CheckStateChanged(object sender, EventArgs e)
        {
            CheckState check = con_isDivce.CheckState;
            if (check == CheckState.Checked)
            {
                modifyItem("IsDivceAdd", "True");
                ConfigHelper.IsDivceAdd = true;

            }

            else
            {
                modifyItem("IsDivceAdd", "False");
                ConfigHelper.IsDivceAdd = false;

            }

        }

        private void btnSyn_ktp_Click(object sender, EventArgs e)
        {
            new TeamWorkerList(false).Show();
            GetVeiveInfo();
        }
    }
}
