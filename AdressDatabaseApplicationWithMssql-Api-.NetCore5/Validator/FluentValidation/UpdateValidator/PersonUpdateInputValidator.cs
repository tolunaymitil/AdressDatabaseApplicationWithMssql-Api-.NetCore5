using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input;
using FluentValidation;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation
{
  public class PersonUpdateInputValidator : AbstractValidator<PersonUpdateInput>
  {
    public PersonUpdateInputValidator()
    {
      RuleFor(f => f.NameSurname).NotNull().WithMessage($"NameSurname Boş bırakılamaz");
            RuleForEach(f => f.Addresses).SetValidator(new AddressUpdateInputValidator());
           // RuleForEach(f => f.Contacts).SetValidator(new ContactUpdateInputValidator());
        }
  }
}
