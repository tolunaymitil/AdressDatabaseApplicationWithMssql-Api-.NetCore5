using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input;
using FluentValidation;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation
{
  public class AddresUpdateInputValidator:AbstractValidator<AddresUpdateInput>
  {
    public AddresUpdateInputValidator()
    {
      RuleFor(f => f.FullAddress).NotEmpty().WithMessage($"FullAddress boş bırakılamaz");
    }
  }
}
