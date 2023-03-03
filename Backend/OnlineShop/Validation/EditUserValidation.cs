using FluentValidation;
using OnlineShop.ViewModel;

namespace OnlineShop.Validation;

public class EditUserValidation : AbstractValidator<EditUserModel>
{
    public EditUserValidation()
    {
        RuleFor(x => x.NationalId)
            .Must(Helper.IsValidNationalID)
            .When(x => !string.IsNullOrEmpty(x.NationalId))
            .WithMessage("کدملی وارد شده معتبر نمیباشد");

        RuleFor(x => x.MobileNumber)
            .Length(11)
            .When(x => !string.IsNullOrEmpty(x.MobileNumber))
            .WithMessage("شماره وارد شده معتبر نمیباشد");
    }
}