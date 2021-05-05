using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        // FluentValidation kullanmak yerine şimdilik if bloğunu kullanarak hallettim. İleride kullanmak için buraya bunu bıraktım.
        public CarValidator()
        {
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(p => p.CarName).NotEmpty().WithMessage("Araba ismi boş olamaz!");
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Ücret Sıfırdan büyük olmalı");
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(270).When(p => p.BrandId == 1).WithMessage("Ücret 270 TL'den düşük olamaz.");
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(260).When(p => p.BrandId == 2);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(260).When(p => p.BrandId == 3);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(250).When(p => p.BrandId == 4);

            //RuleFor(p => p.CarName).Must(StartWithA).WithMessage("Ürün ismi A ile başlamalı");

        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
