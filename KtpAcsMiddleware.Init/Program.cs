using System;
using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Init
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(@"begin...");
                //init admin user
                var orgUserDataService = new OrgUserDataService();
                if (orgUserDataService.FirstOrDefaultAdmin() == null)
                {
                    //add admin user
                    var user = new OrgUser
                    {
                        Id = ConfigHelper.NewGuid,
                        Code = "adminitrator",
                        Name = "Adminitrator",
                        Account = "admin",
                        Password = "123456",
                        Mobile = "-",
                        Mail = "-",
                        Status = (int) OrgUserState.Normal
                    };
                    orgUserDataService.AddUser(user);
                    Console.WriteLine(
                        "add admin user complete,loginName={0},password=123456 \ncontinue...", user.Account);
                }
                //init team worktypes
                if (DataFactory.TeamWorkTypeRepository.FindAll().Count == 0)
                {
                    IList<TeamWorkType> newTeamWorkTypes = new List<TeamWorkType>();
                    newTeamWorkTypes.Add(new TeamWorkType {Value = 19, Name = "木工"});
                    newTeamWorkTypes.Add(new TeamWorkType {Value = 20, Name = "铁工"});
                    newTeamWorkTypes.Add(new TeamWorkType {Value = 21, Name = "混泥土"});
                    newTeamWorkTypes.Add(new TeamWorkType {Value = 22, Name = "外架"});
                    newTeamWorkTypes.Add(new TeamWorkType {Value = 23, Name = "粗装修"});
                    newTeamWorkTypes.Add(new TeamWorkType {Value = 24, Name = "其他"});
                    DataFactory.TeamWorkTypeRepository.Adds(newTeamWorkTypes);
                    Console.WriteLine("add team worktypes complete \ncontinue...");
                }
                ////add test teams  --按需
                //if (DataFactory.TeamService.GetAll().Count == 0)
                //{
                //    var teamWorkTypes = DataFactory.TeamWorkTypeRepository.FindAll();
                //    foreach (var teamWorkType in teamWorkTypes)
                //    {
                //        for (var i = 1; i <= 3; i++)
                //        {
                //            DataFactory.TeamService.Add(new Team
                //            {
                //                Name = $"{teamWorkType.Name}{i}",
                //                WorkTypeId = teamWorkType.Id,
                //                Description = $"测试-{teamWorkType.Name}{i}"
                //            });
                //        }
                //    }
                //    Console.WriteLine("add test teams complete \ncontinue...");
                //}
                //complete
                Console.WriteLine(@"complete");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}