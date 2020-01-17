﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.MyDB.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> Awards { get; set; } = new List<int>();

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
            userSB.Append($"ID: {Id}. Name: {Name}. Date of birth: {DateOfBirth.ToShortDateString()}. ");
            userSB.Append($"Age: {Age}");
            return userSB.ToString();
        }
    }
}