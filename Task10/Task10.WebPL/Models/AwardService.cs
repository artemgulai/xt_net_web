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
    public class AwardService
    {
        private IAwardLogic _awardLogic;
        private StringBuilder _sb;
        IEnumerable<Award> _awards;

        public AwardService()
        {
            _awardLogic = Task06.MyDB.IoC.DependencyResolver.AwardLogic;
            _sb = new StringBuilder();
            _awards = _awardLogic.GetAll();
        }

        public IEnumerable<Award> GetAllAwards()
        {
            return _awardLogic.GetAll();
        }

        public String AddAward(string title)
        {
            var award = _awardLogic.Add(new Award
            {
                Title = title
            });

            return $"Award has been added to DB. ID = {award.Id}";
        }

        public bool RemoveAward(int id)
        {
            return _awardLogic.RemoveById(id);
        }

        public void RemoveAll()
        {
            _awardLogic.RemoveAll();
        }
    }
}