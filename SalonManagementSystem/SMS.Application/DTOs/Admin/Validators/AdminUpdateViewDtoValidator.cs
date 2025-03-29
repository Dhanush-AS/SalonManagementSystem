using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Admin.Validators
{
    public class AdminUpdateViewDtoValidator<T> : AbstractValidator<T> where T : AdminUpdateViewDto
    {
        public AdminUpdateViewDtoValidator() 
        { 
            RuleFor(x=>x.AdminId).NotEmpty().WithMessage("Id should not be empty");
        }
    }
}
