using FluentValidation;
using SMS.Domain;
using SMS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.StylesList.Validators
{
    public class StylesListDtoValidators<T>: AbstractValidator<T> where T : StylesListDto
    {

    }
}
