using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.BLL;
using Task06.BLL.Interfaces;
using Task06.DAL;
using Task06.DAL.Interfaces;

namespace Task06.Ioc
{
    public static class DependencyResolver
    {
        public static IUserDao UserDao { get; private set; }

        public static IUserLogic UserLogic { get; private set; }

        public static IAwardDao AwardDao { get; set; }

        public static IAwardLogic AwardLogic { get; set; } 

        static DependencyResolver()
        {
            var DALConf = ReadSetting("DAL");
            if (DALConf == "File")
            {
                UserDao = new UserFileDao();
                AwardDao = new AwardFileDao();
            }
            else
            {
                UserDao = new UserMemoryDao();
                AwardDao = new AwardMemoryDao();
            }

            UserLogic = new UserLogic(UserDao);
            AwardLogic = new AwardLogic(AwardDao);
            AwardDao.DeleteAward += UserDao.OnDeleteAwardHandler;
        }

        private static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                return "Not Found";
            }
        }
    }
}