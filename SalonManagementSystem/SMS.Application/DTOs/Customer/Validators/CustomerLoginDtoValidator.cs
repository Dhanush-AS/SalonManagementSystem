using FluentValidation;
using SMS.Application.DTOs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Customer.Validators
{
    public class CustomerLoginDtoValidator<T> : AbstractValidator<T> where T : CustomerLoginDto
    {
        public CustomerLoginDtoValidator() 
        {
            RuleFor(x => x.CustomerEmail).ValidateEmail();
            RuleFor(x=> x.Password).ValidatePassword();
        }
    }
}
