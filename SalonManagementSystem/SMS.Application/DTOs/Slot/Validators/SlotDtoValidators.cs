using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Slot.Validators
{
    public class SlotDtoValidators<T> : AbstractValidator<T> where T : SlotDto
    {
        public SlotDtoValidators() 
        {
            
        }
    }
}
