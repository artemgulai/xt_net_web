using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

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

        public override string ToString()
        {
            return $"ID: {Id}. Name: {Name}. Date of birth: {DateOfBirth.ToShortDateString()}. " +
                $"Age: {Age}";
        }
    }
}
