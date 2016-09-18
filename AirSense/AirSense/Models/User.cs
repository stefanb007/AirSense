using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirSense.Models
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string Salt { get; set; }
        public virtual string HashedPass { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual int Weight { get; set; }
        public virtual int Height { get; set; }
        public virtual int Age { get; set; }
        public virtual float BMI { get; set; }
        public virtual string Sex { get; set; }
        public virtual string FitLevel { get; set; }
        public virtual string Goal { get; set; }
        public virtual string Email { get; set; }
        public virtual string RoleId { get; set; }
    }
}