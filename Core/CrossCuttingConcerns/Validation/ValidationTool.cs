using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var resutlt = validator.Validate(context);
            if (!resutlt.IsValid)
            {
                throw new ValidationException(resutlt.Errors);
            }
        }
    }
}
