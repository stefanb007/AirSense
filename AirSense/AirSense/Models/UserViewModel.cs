using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace AirSense.Models
{
    public class UserViewModel
    {
        //baza
        public Guid Id;
        public string Salt;
        public string HashedPass;

        public string Name;
        public string Surname;
        public string Password;
        public string Username;
        public int Weight;
        public int Height;
        public int Age;
        public float BMI;
        public string Sex;
        public string FitLevel;
        public string Goal;

    }

    //public class
}