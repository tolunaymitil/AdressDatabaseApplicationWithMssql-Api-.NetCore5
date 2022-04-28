using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input.AddInput;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation.AddValidator
{
    public class AddressAddInputValidator : AbstractValidator<AddressAddInput>
    {
        public AddressAddInputValidator()
        {
            RuleFor(f => f.FullAddress).NotEmpty().WithMessage($"Şehir Adı boş bırakılamaz");
            RuleFor(f => f.County).NotEmpty().WithMessage($"İlçe Adı boş bırakılamaz");
            RuleFor(x => x.FullAddress).MaximumLength(150).WithMessage("Lütfen 150 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.FullAddress).MinimumLength(50).WithMessage("Lütfen en az 50 karakter giriniz");
        }
    }
}
