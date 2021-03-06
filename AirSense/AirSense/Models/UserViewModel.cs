﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public virtual string Password { get; set; }
        public virtual string ConfirmPassword { get; set; }
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
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Enter password");
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Enter email")
                .EmailAddress().WithMessage("This is not a valid email address");
        }
    }


    public class LoginViewModel
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(l => l.Username)
                .NotEmpty().WithMessage("Username must not be empty!");
            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password must not be empty!");
        }
    }

    public class SignupViewModel
    {
        public virtual Guid Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string RoleId { get; set; }
        public virtual string Salt { get; set; }
        public virtual string HashedPass { get; set; }
        public virtual string Password { get; set; }

    }

}