using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.AddInput;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation.AddValidator
{
    public class PersonAddInputValidator : AbstractValidator<PersonAddInput>
    {
        public PersonAddInputValidator()
        {
            RuleFor(f => f.NameSurname).NotNull().WithMessage($"NameSurname Boş bırakılamaz");
            
        }
    }
}
