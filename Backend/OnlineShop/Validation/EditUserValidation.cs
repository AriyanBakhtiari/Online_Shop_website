using FluentValidation;
using OnlineShop.ViewModel;

namespace OnlineShop.Validation;

public class EditUserValidation : AbstractValidator<EditUserModel>
{
    public EditUserValidation()
    {
        RuleFor(x => x.NationalId)
            .Must(Helper.IsValidNationalID)
            .WithMessage("کدملی وارد شده معتبر نمیباشد");

        RuleFor(x => x.MobileNumber)
            .Matches($"(0|\\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}")
            .WithMessage("شماره وارد شده معتبر نمیباشد");
    }
}