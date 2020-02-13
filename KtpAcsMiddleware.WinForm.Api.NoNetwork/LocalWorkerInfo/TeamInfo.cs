using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.WinForm.Api.NoNetwork.FileModel
{
    public class TeamInfo
    {
        List<Team> listTeam = DataAddorRead.Park.team;
        /// <summary>
        /// 新增班组
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public string AddTeam(Team team)
        {
            try
            {
                team.uproid = ConfigHelper.KtpLoginProjectId;
                var list = GetTeams();
                //新建默认班组
                if (list.Exists(a => a.organName == team.organName))
                {
                    return "该班组名已存在";
                }
                int count = listTeam.Count + 1;
                team.localId = count;
                team.sectionId = count;
                listTeam.Add(team);
               // DataAddorRead.Park.team = list;
                DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {

                LogHelper.ExceptionLog("本地新增班组:" + ex);
                return ex.Message;
            }
            return "";
        }
        /// <summary>
        /// 编辑班组
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public string EditTeam(Team team)
        {
            try
            {
                team.uproid = ConfigHelper.KtpLoginProjectId;
                var list = GetTeams();
                //新建默认班组
                if (list.Any(a => a.organName == team.organName && team.localId != a.localId))
                {
                    return "该班组名已存在";
                }
                listTeam[team.localId - 1] = team;

                //DataAddorRead.Park.team = list;
                var save = new WorkerInfo().SetTeamWorker(team.localId, team.organName);
                if (save == "")
                    DataAddorRead.SetDataInfo();
                else
                    return save;
            }
            catch (Exception ex)
            {

                LogHelper.ExceptionLog("本地编辑班组:" + ex);
                return ex.Message;
            }
            return "";
        }
       
        /// <summary>
        /// 设备班组长
        /// </summary>
        /// <param name="wid">工人id</param>
        /// <returns></returns>
        public string SetForeman(int wid)
        {


            try
            {
                Workers worker = new WorkerInfo().GetWorker(wid);
                Team team = GetTeam(worker.localTeamId);

                team.isSyn = false;
                team.userName = worker.urealname;
                team.phoneNum = worker.uname;
                team.identityNum = worker.usfz;
                var list = DataAddorRead.Park.team;
                list[team.localId - 1] = team;

                //DataAddorRead.Park.team = list;
                DataAddorRead.SetDataInfo();
            }
            catch (Exception ex)
            {
                string mag = "本地设备班组长失败:";
                LogHelper.ExceptionLog(mag + ex);
                return mag + ex.Message;

            }
            return "";
        }

        public Team GetTeam(int? id)
        {

            return new TeamInfo().GetTeams().FirstOrDefault(a => a.sectionId == id);
        }
        /// <summary>
        /// 添加默认班组
        /// </summary>
        public void AddDefult()
        {
            try
            {

             
                //新建默认班组
                if (listTeam.Count < 1)
                {
                    List<Team> teams = new List<Team>
            {
                 new Team{  organName="默认部门", localId=1, sectionId=1, uproid=ConfigHelper.KtpLoginProjectId, state=1, createTime=DateTime.Now, teamWorkType=24},
                 new Team{  organName="建信开太平", localId=2,sectionId=2,uproid=ConfigHelper.KtpLoginProjectId, state=1, createTime=DateTime.Now,teamWorkType=24}
            };

                    DataAddorRead.Park.team = teams;
                    DataAddorRead.SetDataInfo();
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog("本地添加默认班组:" + ex);
                throw;
            }
        }
        /// <summary>
        /// 查询班组
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<Team> GetTeams(bool isDel = false)
        {

            var list = DataAddorRead.Park.team;
            if (isDel)
            {
                return list.Where(a => a.isDel == true &&  a.uproid== ConfigHelper.KtpLoginProjectId).ToList();
            }

            return list.Where(a => a.isDel == false && a.uproid == ConfigHelper.KtpLoginProjectId).ToList();

        }

    }
}
