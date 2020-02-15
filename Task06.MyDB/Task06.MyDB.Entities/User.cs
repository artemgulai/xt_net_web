using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task06.MyDB.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> Awards { get; set; } = new List<int>();
        public byte[] UserImage { get; set; }

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
            StringBuilder userSB = new StringBuilder();
            userSB.Append($"ID: {Id}. Name: {Name}. Date of birth: {DateOfBirth.ToString("dd.MM.yyyy",new System.Globalization.CultureInfo("ru-RU"))}. ");
            userSB.Append($"Age: {Age}");
            return userSB.ToString();
        }
    }
}
