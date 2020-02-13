using CCWin;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
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

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork.TeamWorkers
{
    public partial class AddTeamInfo : Skin_Color
    {
        Team team = null;
        public AddTeamInfo()
        {
            InitializeComponent();
            GetTeamType();
        }
        public AddTeamInfo(int id)
        {
            InitializeComponent();
            team = new TeamInfo().GetTeam(id);
            if (team != null)
            {
                TeamIdLabel.Text = team.sectionId.ToString();
                NameTxt.Text = team.organName;
                txtIc.Text = team.identityNum;
                txtMobile.Text = team.phoneNum;
                txtName.Text = team.userName;
                GetTeamType(team.teamWorkType);
            }
        }

        private void AddTeamInfo_Load(object sender, EventArgs e)
        {

        }

        public void GetTeamType(int selectedValue = 0)
        {

            var workTypes = DataAddorRead.Park.teamWorkTypes;
            TeamWorkType type = new TeamWorkType { Value = 0, Name = "选择" };
            workTypes.Add(type);
            WorkTypeIdsCb.DataSource = workTypes;
            WorkTypeIdsCb.DisplayMember = "Name";
            WorkTypeIdsCb.ValueMember = "Value";
            WorkTypeIdsCb.SelectedValue = selectedValue;
            workTypes.Remove(type);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var isPrePass = true;
                PreValidationHelper.InitPreValidation(FormErrorProvider);
                PreValidationHelper.MustNotBeNull(FormErrorProvider, WorkTypeIdsCb, "工种必需选择", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, NameTxt, "班组名称不能为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, txtMobile, "班组长手机不能为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, txtName, "班组长姓名不能为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, txtIc, "班组长身份证号不能为空", ref isPrePass);
                PreValidationHelper.IsMobile(FormErrorProvider, txtMobile, "手机号码格式错误", ref isPrePass);
                PreValidationHelper.IsIdCard(FormErrorProvider, txtIc, "身份证号格式错误", ref isPrePass);
                if (!isPrePass)
                {
                    throw new PreValidationException(PreValidationHelper.ErroMsg);
                }

                var name = NameTxt.Text.Trim();
                var id = TeamIdLabel.Text;
                var uName = txtName.Text;
                var mobile = txtMobile.Text;
                var ic = txtIc.Text;
                var teamWorkType = FormatHelper.StringToInt(WorkTypeIdsCb.SelectedValue.ToString());
                string save = "";

                if (!string.IsNullOrEmpty(id))
                {
                    team.organName = name;
                    team.teamWorkType = teamWorkType;
                    team.identityNum = ic;
                    team.userName = uName;
                    team.phoneNum = mobile;
                    team.isSyn = false;
                    save = new TeamInfo().EditTeam(team);
                }
                else
                {
                    team = new Team
                    {
                        organName = name,
                        state = 2,
                        createTime = DateTime.Now,
                        teamWorkType = teamWorkType,
                        phoneNum = mobile,
                        userName = uName,
                        identityNum = ic
                    };
                    save = new TeamInfo().AddTeam(team);
                }
                if (save != "")
                {
                    FormErrorProvider.SetError(NameTxt, "班组名称不允许重复");
                    throw new PreValidationException("班组名称不允许重复");
                }

                Hide();
            }
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
