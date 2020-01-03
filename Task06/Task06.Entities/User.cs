using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Entities
{
    public class User
    {
        private ISet<int> _awards;

        public User()
        {
            _awards = new SortedSet<int>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ISet<int> Awards { 
            get => _awards; 
            set => _awards = value; 
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Now;
                int age = today.Year - DateOfBirth.Year;
                if (today.AddYears(-age) < DateOfBirth) age--;
                return age;
            }
        }

        public bool AddAward(int awardId)
        {
            return _awards.Add(awardId);
        }

        public bool RemoveAward(int awardId)
        {
            return _awards.Remove(awardId);
        }

        public override string ToString()
        {
            StringBuilder userSB = new StringBuilder();
            userSB.Append($"ID: {Id}. Name: {Name}. Date of birth: {DateOfBirth.ToShortDateString()}. ");
            userSB.Append($"Age: {Age}");
            return userSB.ToString();
        }
    }
}
