using FluentValidation;
using SMS.Application.DTOs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Services.Validators
{
    public class ServicesDtoValidator<T>:AbstractValidator<T> where T : ServicesDto
    {
        public ServicesDtoValidator() 
        {
            RuleFor(x => x.ServiceName).ValidateNames();
            RuleFor(x => x.Description).MaximumLength(30).WithMessage("Description exceeds the limit");
            RuleFor(x => x.Duration).NotEmpty().WithMessage("Duration Cannot be empty");
        }
    }
}
