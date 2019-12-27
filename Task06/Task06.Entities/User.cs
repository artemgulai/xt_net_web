using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Entities
{
    public class User
    {
        private Dictionary<int,Award> _awards;

        public User()
        {
            _awards = new Dictionary<int,Award>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Dictionary<int,Award> Awards { 
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

        // TODO change return type to bool?
        public bool AddAward(Award award)
        {
            try
            {
                Awards.Add(award.Id,award);
                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
            }
        }

        // TODO change return type to bool?
        public bool RemoveAward(Award award)
        {
            return Awards.Remove(award.Id);
        }

        public override string ToString()
        {
            StringBuilder userSB = new StringBuilder();
            userSB.Append($"ID: {Id}. Name: {Name}. Date of birth: {DateOfBirth.ToShortDateString()}. ");
            userSB.Append($"Age: {Age}");
            if (Awards.Count != 0)
            {
                userSB.Append(Environment.NewLine + "Awards:");
                foreach(var item in Awards)
                {
                    userSB.Append($" {item.Value.Title},");
                }
                userSB.Remove(userSB.Length - 1,1);
            }
            return userSB.ToString();
        }
    }
}
