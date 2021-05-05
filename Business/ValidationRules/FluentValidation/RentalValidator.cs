using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CustomerId).NotEqual(r => r.CustomerId);
            RuleFor(r => r.CarId).NotEmpty().NotEqual(r => r.CarId);
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentalId).NotEqual(r => r.RentalId);
            RuleFor(r => r.ReturnDate).NotNull();


        }
    }
}
