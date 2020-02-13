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
    public class UserInfo
    {
        /// <summary>
        ///工人列表
        /// </summary>
        public List<Workers> workers = new List<Workers>();
        /// <summary>
        /// 班组列表
        /// </summary>
        public List<Team> team = new List<Team>();
        /// <summary>
        /// 班组类型
        /// </summary>
        public List<TeamWorkType> teamWorkTypes=new List<TeamWorkType>();
        /// <summary>
        /// 项目信息
        /// </summary>
        public ProjectInfo projectInfo = new ProjectInfo();
      

        //初始化数据
        public void Inte()
        {
            DataAddorRead.GetDataInfo();
            UserInfo userInfo = DataAddorRead.Park;
            //新建班组类型
            if (userInfo.teamWorkTypes.Count < 1)
            {
                List<TeamWorkType> newTeamWorkTypes = new List<TeamWorkType>();
                newTeamWorkTypes.Add(new TeamWorkType { Value = 19, Name = "木工" });
                newTeamWorkTypes.Add(new TeamWorkType { Value = 20, Name = "铁工" });
                newTeamWorkTypes.Add(new TeamWorkType { Value = 21, Name = "混泥土" });
                newTeamWorkTypes.Add(new TeamWorkType { Value = 22, Name = "外架" });
                newTeamWorkTypes.Add(new TeamWorkType { Value = 23, Name = "粗装修" });
                newTeamWorkTypes.Add(new TeamWorkType { Value = 24, Name = "其他" });

                DataAddorRead.Park.teamWorkTypes = newTeamWorkTypes;
            }
           
            DataAddorRead.SetDataInfo();



        }
    }
}
