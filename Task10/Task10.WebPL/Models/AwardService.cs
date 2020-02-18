using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task06.MyDB.IoC;
using Task06.MyDB.BLL.Interfaces;
using System.Text;
using Task06.MyDB.Entities;
using System.Web.Mvc;

namespace Task10.WebPL.Models
{
    public static class AwardService
    {
        private static IAwardLogic _awardLogic;
        private static StringBuilder _sb;
        private static IEnumerable<Award> _awards;

        static AwardService()
        {
            _awardLogic = Task06.MyDB.IoC.DependencyResolver.AwardLogic;
            _sb = new StringBuilder();
            _awards = _awardLogic.GetAll();
        }

        public static IEnumerable<Award> GetAllAwards()
        {
            return _awardLogic.GetAll();
        }

        public static string AddAward(string title, byte[] image = null)
        {
            var award = new Award { Title = title };

            if (image != null)
            {
                award.AwardImage = image;
            }

            award = _awardLogic.Add(award);

            return $"Award has been added to DB. ID = {award.Id}";
        }

        public static bool RemoveAward(int id)
        {
            return _awardLogic.RemoveById(id);
        }

        public static void RemoveAll()
        {
            _awardLogic.RemoveAll();
        }

        public static Award GetAwardById(int id)
        {
            return _awardLogic.GetById(id);
        }

        public static bool UpdateAward(Award award)
        {
            return _awardLogic.Update(award);
        }
    }
}