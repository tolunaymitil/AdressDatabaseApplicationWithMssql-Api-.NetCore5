using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input;
using FluentValidation;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation
{
  public class AddressUpdateInputValidator:AbstractValidator<AddresUpdateInput>
  {
    public AddressUpdateInputValidator()
    {
      RuleFor(f => f.FullAddress).NotEmpty().WithMessage($"FullAddress boş bırakılamaz");
       RuleFor(x => x.FullAddress).MinimumLength(50).WithMessage("Lütfen en az 50 karakter giriniz");
        }
  }
}
