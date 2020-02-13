using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using CCWin;
using KtpAcsAotoUpdate;


using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.NoNetwork;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel;
using KtpAcsMiddleware.WinForm.Api.Shared;

namespace KtpAcsMiddleware.WinForm.Api
{
    public partial class Login : Skin_Color
    {
        public Login()
        {
            InitializeComponent();






        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }
        private static void CheckUpdateApplication()
        {
            if (ConfigurationManager.AppSettings["IsAutoUpdater"] == "True")
            {

                Application.EnableVisualStyles();
                AutoUpdater au = new AutoUpdater();
                try
                {
                    au.Update();
                }
                catch (WebException exp)
                {
                    MessageBox.Show(String.Format("更新无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (XmlException exp)
                {
                    MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NotSupportedException exp)
                {
                    MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException exp)
                {
                    MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var loginBtnText = LoginBtn.Text;
            try
            {
                LoginBtn.Text = @"正在登录";
                LoginBtn.Enabled = false;
                FormErrorProvider.Clear();
                var loginErroMsg = @"用户名或者密码错误";
                if (string.IsNullOrEmpty(UserNameTxt.Text))
                {
                    loginErroMsg = "用户名不允许为空";
                    FormErrorProvider.SetError(UserNameTxt, loginErroMsg);
                    throw new PreValidationException(loginErroMsg);
                }
                if (string.IsNullOrEmpty(PasswordTxt.Text))
                {
                    loginErroMsg = "密码不允许为空";
                    FormErrorProvider.SetError(PasswordTxt, loginErroMsg);
                    throw new PreValidationException(loginErroMsg);
                }

                if (UserNameTxt.Text == "admin" && PasswordTxt.Text == "123456")
                {

                    if (ConfigHelper.KtpUploadNetWork)
                    {
                        loginErroMsg = "默认账号只能是无网络状态下才能登陆，请登陆后台创建的账号";
                        FormErrorProvider.SetError(PasswordTxt, loginErroMsg);
                        throw new PreValidationException(loginErroMsg);
                    }
                    ConfigHelper._KtpLoginProjectId = ConfigHelper.ProjectId;

                }
                else
                {
                    if (ConfigHelper.KtpUploadNetWork)
                    {
                        IMulePusher pusherLogin = new LoginApi() { RequestParam = new { account = UserNameTxt.Text, passWord = PasswordTxt.Text } };
                        PushSummary pushLogin = pusherLogin.Push();
                        if (!pushLogin.Success)
                        {
                            MessageHelper.Show(pushLogin.Message);
                            return;
                        }
                        LoginResult rpushLogin = pushLogin.ResponseData;
                        if (!rpushLogin.success)
                        {
                            loginErroMsg = "用户名或密码不正确";
                            FormErrorProvider.SetError(PasswordTxt, loginErroMsg);
                            throw new PreValidationException(loginErroMsg);
                        }

                    }
                    else
                    {
                        loginErroMsg = "用户名或密码不正确";
                        FormErrorProvider.SetError(PasswordTxt, loginErroMsg);
                        throw new PreValidationException(loginErroMsg);
                    }
                }

                Hide();
                new Home().Show();
            }
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex.Message);
            }
            finally
            {
                LoginBtn.Text = loginBtnText;
                LoginBtn.Enabled = true;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }
        /// <summary>
        /// 加载网络
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {


            GetNetWorkInfoLoad();

            if (ConfigHelper.KtpUploadNetWork)
            {
                Thread thread = new Thread(CheckUpdateApplication);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
              
                pl_ts.Visible = true;

            }
        }

        private void menu_application_Exit_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

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
            CheckState check = menu_application_IsManualAddInfo.CheckState;
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
        /// 加载网络信息
        /// </summary>
        private void GetNetWorkInfoLoad()
        {


            //网络情况是否联网
            string url = "www.baidu.com";
            bool isconn = ConfigHelper.KtpUploadNetWork;
            Ping ping = new Ping();
            try
            {
                int timeout = 5;//设置超时时间             
                PingReply pr = ping.Send(url, timeout);
                if (pr.Status == IPStatus.Success)
                {//连接正常情况下

                    ConfigHelper.KtpUploadNetWork = true;
                    //ConfigHelper.KtpUploadNetWork = false;

                }


            }
            catch (Exception ex)
            {

                LogHelper.ExceptionLog(ex);
            }



        }

    }
}