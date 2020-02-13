using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel
{
    [Serializable]
    public class ProjectInfo
    {
        /// <summary>
        ///项目名称
        /// </summary>
        public string projectName { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        public int projectId { get; set; }
        public string loginName { get; set; }
        public int loginPwd { get; set; }

        //public ProjectInfo(string projectName, int projectId) {

        //    this.projectId = projectId;
        //    this.projectName = projectName;
        //}
        /// <summary>
        /// 有网状态修改无网设置的id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public string SetTeamWorkerProjectId(int projectId)
        {
            try
            {
                List<Team> listTeam = DataAddorRead.Park.team;
                List<Workers> listWorers = DataAddorRead.Park.workers;
                //修改班组的项目id
                listTeam.ForEach(w => w.uproid = projectId);
                //修改工人的项目id
                listWorers.ForEach(w => w.uproid = projectId);
                DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {

                LogHelper.ExceptionLog(" 修改项目信息出错:" + ex);
                return " 修改项目信息出错:"+ex.Message;
                throw;
            }
            return "";
        }
    }
}
