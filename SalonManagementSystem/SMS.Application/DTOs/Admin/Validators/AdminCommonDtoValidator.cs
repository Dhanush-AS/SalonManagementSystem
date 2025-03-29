using FluentValidation;
using SMS.Application.DTOs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Admin.Validators
{
    public class AdminCommonDtoValidator<T> : AbstractValidator<T> where T : AdminCommonDto
    {
        public AdminCommonDtoValidator() {
            RuleFor(x => x.AdminName).ValidateNames();
            RuleFor(x => x.FirstName).ValidateNames();
            RuleFor(x => x.LastName).ValidateNames();
            RuleFor(x => x.Email).ValidateEmail();
            RuleFor(x => x.PhoneNumber).ValidatePhoneNo();
            RuleFor(x => x.Password).ValidatePassword();
        }
    }
}
