using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class SecurityBll
    {
        public static void Login(string newUser, string oldUser)
        {
            AbsScheduleLoginRepository scheduleLoginRepository = new AbsScheduleLoginRepository();
            absScheduleLoginEntity entity = new absScheduleLoginEntity();
            entity.UserId = newUser;
            entity.User = oldUser;
            entity.ProgramName = ConfigurationBLL.ProgramName;
            scheduleLoginRepository.Add(entity);
            if (!(oldUser != entity.UserId))
                return;
            absScheduleLoginEntity byUserId = scheduleLoginRepository.GetByUserId(ConfigurationBLL.ProgramName, oldUser);
            if (byUserId == null)
                return;
            scheduleLoginRepository.Delete(byUserId);
        }
        
        public static string LogInNewUser(string user)
        {
            string str = (string)null;
            UserSecurityEntity userSecurity = SecurityBll.GetUserSecurity(user);
            if (userSecurity != null && ((bool?)userSecurity.WorkScheduleMaintenance).HasValue && ((bool?)userSecurity.WorkScheduleMaintenance).Value)
            {
                if (SecurityBll.AlreadyLoggedIn(user))
                {
                    //int num1 = (int)MessageBox.Show(user + " is already logged in to this program.");
                }
                else
                {
                    SecurityBll.Login(user);
                    str = user;
                }
            }
            else
            {
                /*
                frmChangeUser frmChangeUser = new frmChangeUser(user);
                int num2 = (int)frmChangeUser.ShowDialog();
                if (frmChangeUser.MyUser != null)
                {
                    str = frmChangeUser.MyUser.Trim();
                }
                else
                {
                    int num3 = (int)MessageBox.Show(user + " is not authorized to use this program.");
                }
                */
            }
            return str;
        }
        
        public static void LogOutUser(string user)
        {
            AbsScheduleLoginRepository scheduleLoginRepository = new AbsScheduleLoginRepository();
            absScheduleLoginEntity byUserId = scheduleLoginRepository.GetByUserId(ConfigurationBLL.ProgramName, user);
            if (byUserId == null)
                return;
            scheduleLoginRepository.Delete(byUserId);
        }

        public static UserSecurityEntity GetUserSecurity(string user)
        {
            return new UserSecurityRepository().GetByLogIn(user);
        }

        public static List<UserSecurityEntity> GetUserSecurity()
        {
            return new UserSecurityRepository().GetAll().OrderBy<UserSecurityEntity, string>((Func<UserSecurityEntity, string>)(c => c.LogIn)).ToList<UserSecurityEntity>();
        }

        public static void UpdateUserSecurity(UserSecurityEntity user)
        {
            new UserSecurityRepository().Update(user);
        }

        public static bool AlreadyLoggedIn(string user)
        {
            AbsScheduleLoginRepository scheduleLoginRepository = new AbsScheduleLoginRepository();
            if (user == null)
                return false;
            return scheduleLoginRepository.GetByUserId(ConfigurationBLL.ProgramName, user) != null;
        }

        public static void Login(string user)
        {
            new AbsScheduleLoginRepository().Add(new absScheduleLoginEntity()
            {
                UserId = user,
                User = user,
                ProgramName = ConfigurationBLL.ProgramName
            });
        }
    }
}