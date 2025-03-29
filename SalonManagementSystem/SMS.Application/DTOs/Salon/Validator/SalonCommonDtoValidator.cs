using FluentValidation;
using SMS.Application.DTOs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Salon.Validator
{
    public class SalonCommonDtoValidator<T> : AbstractValidator<T> where T : SalonCommonDto
    {
        public SalonCommonDtoValidator()
        {
            RuleFor(x => x.SalonName).ValidateNames();
            RuleFor(x => x.Address).MaximumLength((50)).WithMessage("Address should not exceed more than 50 characters");
            RuleFor(x => x.Pincode).NotEmpty().WithMessage("Pincode cannot be empty");
            RuleFor(x=>x.PhoneNumber).ValidatePhoneNo();
            RuleFor(x=>x.Description).MaximumLength(50).WithMessage("Description should not exceed more than 50 characters");
        }
    }
}
