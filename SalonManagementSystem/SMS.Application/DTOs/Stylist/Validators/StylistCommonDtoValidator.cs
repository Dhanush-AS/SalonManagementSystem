using FluentValidation;
using SMS.Application.DTOs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Stylist.Validators
{
    public class StylistCommonDtoValidator<T> : AbstractValidator<T> where T : StylistCommonDto
    {
        public StylistCommonDtoValidator() 
        {
            RuleFor(x => x.StylistName).ValidateNames();
            RuleFor(x => x.Experience).NotEmpty().WithMessage("Experience cannot be empty");
            RuleFor(x => x.Specializations).NotEmpty().WithMessage("Specializations cannot be empty");
            RuleFor(x=>x.Email).ValidateEmail();
            RuleFor(x=>x.PhoneNumber).ValidatePassword();
            RuleFor(x => x.WorkingHours).NotEmpty().WithMessage("Working Hours cannot be empty");
            
        }
    }
}
