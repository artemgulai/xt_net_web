using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Entities
{
    public class User
    {
        private int _id;
        private string _name;
        private DateTime _dateOfBirth;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Now;
                int age = today.Year - _dateOfBirth.Year;
                if (today.AddYears(-age) < _dateOfBirth) age--;
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
