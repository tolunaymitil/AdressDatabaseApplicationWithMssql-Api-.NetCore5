using AdressDatabaseApplicationWithMssql_Api_.NetCore5.Dtos.Input;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.Validator.FluentValidation
{
    public class ContactAddInputValidator : AbstractValidator<ContactUpdateInput>
    {
        public ContactAddInputValidator()
        {
            RuleFor(x => x.ContactType).NotEmpty().WithMessage("İletişim Tipini Boş Geçemezsiniz");
            RuleFor(x => x).Custom((model, context) => ContactValueCheckWithType(model, context));
        }

        private bool ContactValueCheckWithType(ContactUpdateInput contactAddInput, ValidationContext<ContactUpdateInput> context)
        {
            string contactValue = contactAddInput.ContactValue;
            switch (contactAddInput.ContactType)
            {
                case DataLayer.Entities.Enum.ContactType.Email:
                    if (IsEmailValidate(contactValue) == false)
                    {
                        context.AddFailure($"{contactValue} email değildir");
                        return false;
                    }
                    return true;
                case DataLayer.Entities.Enum.ContactType.Phone:
                    if (IsGsmValidate(contactValue) == false)
                    {
                        context.AddFailure($"{contactValue} gsm değildir");
                        return false;
                    }
                    return true;
                case DataLayer.Entities.Enum.ContactType.Sms:
                    if (IsGsmValidate(contactValue) == false)
                    {
                        context.AddFailure($"{contactValue} gsm değildir");
                        return false;
                    }
                    return true;
                case DataLayer.Entities.Enum.ContactType.Whatsapp:
                    if (IsGsmValidate(contactValue) == false)
                    {
                        context.AddFailure($"{contactValue} gsm değildir");
                        return false;
                    }
                    return true;
            }
            context.AddFailure($"Geçerli bir contacttype göndermediniz");
            return false;
        }
        private bool IsEmailValidate(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,30})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;

            return false;
        }
        private bool IsGsmValidate(string gsm)
        {
            Regex regex = new Regex(@"^\(?([0-9]{3})\)?([0-9]{3})?([0-9]{4})$");
            Match match = regex.Match(gsm);
            if (match.Success)
                return true;
            return false;
        }
    }
}