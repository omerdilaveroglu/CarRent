using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.ImagePath).NotEmpty();
        }
    }
}
