using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace AirSense.Models
{
    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        //baza
        public virtual Guid Id { get; set; }
        public virtual string Salt { get; set; }
        public virtual string HashedPass { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Username { get; set; }
        public virtual int Weight { get; set; }
        public virtual int Height { get; set; }
        public virtual int Age { get; set; }
        public virtual float BMI { get; set; }
        public virtual string Sex { get; set; }
        public virtual string FitLevel { get; set; }
        public virtual string Goal { get; set; }
        public virtual string Role { get; set; }
        public virtual string Email { get; set; }

    }

    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Enter first name");
            RuleFor(r => r.Surname)
                .NotEmpty().WithMessage("Enter last name");
            RuleFor(r => r.Username)
                .NotEmpty().WithMessage("Enter username");
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Enter email")
                .EmailAddress().WithMessage("This is not a valid email address");
        }
    }

}