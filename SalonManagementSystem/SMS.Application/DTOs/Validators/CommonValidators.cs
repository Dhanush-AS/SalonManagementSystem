using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Validators
{
    public static class CommonValidators
    {
        public static IRuleBuilder<T, string> ValidateEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.
                NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Enter a valid email address");
        }
        public static IRuleBuilderOptions<T, string> ValidatePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(6).WithMessage("Password should have at least 6 characters")
                .MaximumLength(15).WithMessage("Password should not exceed 15 characters")
                .Must(HasUpperCase).WithMessage("Password must contain at least one uppercase letter.")
                .Must(HasSpecialCharacter).WithMessage("Password must contain at least one special character.");

        }
        public static IRuleBuilderOptions<T, string> ValidateNames<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Name cannot not be empty")
                .MaximumLength(30).WithMessage("Name should not exceed 30 characters");
        }
        public static IRuleBuilderOptions<T, string> ValidatePhoneNo<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Phone number cannot not be empty")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be exactly 10 digits.");
        }
        public static IRuleBuilderOptions<T, string> ValidateID<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("ID number cannot not be empty");
        }

        //functions
        private static bool HasUpperCase(string password) =>
            !string.IsNullOrEmpty(password) && password.Any(char.IsUpper);

        private static bool HasSpecialCharacter(string password) =>
            !string.IsNullOrEmpty(password) && password.Any(ch => !char.IsLetterOrDigit(ch));
    }


}