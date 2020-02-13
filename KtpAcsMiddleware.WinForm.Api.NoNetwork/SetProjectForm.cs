using CCWin;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork
{
    public partial class SetProjectForm : Skin_Color
    {
        private bool _isEdit = false;
        public SetProjectForm()
        {
            InitializeComponent();
            ExitButton.Focus();
        }
        public SetProjectForm(bool isEdit)
        {
            InitializeComponent();
            label3.Visible = false;
            ExitButton.Text = "关 闭";
            if (!isEdit)
            {
                txt_proId.ReadOnly = true;
                UserNameTxt.ReadOnly = true;
                SaveBtn.Enabled = false;

            }
            else
            {
                _isEdit = true;
                SaveBtn.Text = "修 改";
            }
            GetProjectInfo();
            ExitButton.Focus();
        }

        public void GetProjectInfo()
        {
            ProjectInfo projectInfo = DataAddorRead.Park.projectInfo;
            if (projectInfo.projectId == 0 || projectInfo.projectName == "")
            {
                MessageHelper.Show("未设置项目");
                this.Close();
            }
            else
            {
                this.txt_proId.Text = projectInfo.projectId.ToString();
                this.UserNameTxt.Text = projectInfo.projectName;
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {

                if (MessageBox.Show($@"修改将全部人员默认项目修改,确定要修改离线录入人员设置的项目吗？", @"删除提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string loginErroMsg = "";
                        ProjectInfo projectInfo = SetPrjectInfo(ref loginErroMsg);
                        projectInfo.SetTeamWorkerProjectId(projectInfo.projectId);
                        this.Close();
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

                }
            }
            else
            {

                try
                {
                    string loginErroMsg = "";
                    ProjectInfo projectInfo = SetPrjectInfo(ref loginErroMsg);
                    ConfigHelper._KtpLoginProjectId = projectInfo.projectId;
                    ConfigHelper._KtpLoginProjectName = projectInfo.projectName;
                    this.Close();
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
            }


        }

        private ProjectInfo SetPrjectInfo(ref string loginErroMsg)
        {
            ProjectInfo projectInfo = DataAddorRead.Park.projectInfo;
            projectInfo.projectName = this.UserNameTxt.Text;
            projectInfo.projectId = FormatHelper.StringToInt(this.txt_proId.Text);
            if (string.IsNullOrEmpty(projectInfo.projectName))
            {
                loginErroMsg = "项目名称不允许为空";
                FormErrorProvider.SetError(UserNameTxt, loginErroMsg);
                throw new PreValidationException(loginErroMsg);
            }
            if (projectInfo.projectId == 0)
            {
                loginErroMsg = "项目id不允许为空";
                FormErrorProvider.SetError(txt_proId, loginErroMsg);
                throw new PreValidationException(loginErroMsg);
            }
            DataAddorRead.Park.projectInfo = projectInfo;
            DataAddorRead.SetDataInfo();
            return projectInfo;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (ExitButton.Text == "关 闭")
                this.Close();
            else
                Application.Exit();
        }

        private void txt_proId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void SetProjectForm_Load(object sender, EventArgs e)
        {
            ExitButton.Focus();
        }
    }
}
