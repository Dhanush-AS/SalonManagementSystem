using FluentValidation;
using SMS.Application.DTOs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Customer.Validators
{
    public class CustomerUpdateViewDtoValidator<T> : AbstractValidator<T> where T : CustomerUpdateViewDto
    {
        public CustomerUpdateViewDtoValidator()
        {
            RuleFor(x => x.CustomerEmail).ValidateEmail();
            RuleFor(x => x.PhoneNumber).ValidatePhoneNo();
            RuleFor(x => x.CustomerName).ValidateNames();
            RuleFor(x => x.FirstName).ValidateNames();
            RuleFor(x => x.LastName).ValidateNames();
            RuleFor(x => x.City).NotEmpty().WithMessage("City cannot be empty");
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender cannot be empty");
            RuleFor(x => x.Pincode).NotEmpty().WithMessage("Pincode cannot be empty");
            RuleFor(x => x.Password).ValidatePassword();

        }
    }
}
