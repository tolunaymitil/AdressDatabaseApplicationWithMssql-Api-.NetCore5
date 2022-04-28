using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.AddInput;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation.AddValidator
{
    public class ContactAddInputValidator : AbstractValidator<ContactAddInput>
    {
        public ContactAddInputValidator()
        {
            RuleFor(x => x.ContactType).NotEmpty().WithMessage("İletişim Tipini Boş Geçemezsiniz");

            if ( )
            {
                RuleFor(x => x.ContactValue).EmailAddress();
            }
            else
            {
               
            }
        }
    }
}
