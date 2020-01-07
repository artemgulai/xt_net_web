using System;
using System.Collections.Generic;
using System.Text;

namespace Task06.Entities
{
    public class User
    {
        public User()
        {
            Awards = new SortedSet<int>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ISet<int> Awards { get; }

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
            return Awards.Add(awardId);
        }

        public bool RemoveAward(int awardId)
        {
            return Awards.Remove(awardId);
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
