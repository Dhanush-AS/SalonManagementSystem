using FluentValidation;
using SMS.Application.DTOs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Admin.Validators
{
    public class AdminLoginDtoValidator<T> : AbstractValidator<T> where T : AdminLoginDto
    {
        public AdminLoginDtoValidator() 
        {
            RuleFor(x => x.Email).ValidateEmail();
            RuleFor(x => x.Password).ValidatePassword();
        }
    }
}
