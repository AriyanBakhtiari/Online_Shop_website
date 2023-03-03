using FluentValidation;
using OnlineShop.ViewModel;

namespace OnlineShop.Validation;

public class SignUpValidation : AbstractValidator<SignUpViewModel>
{
    public SignUpValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("ایمیل را وارد نمایید.")
            .Matches("^\\S+@\\S+\\.\\S+$")
            .WithMessage("ایمیل وارد شده معتبر نمیباشد.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("لطفا پسورد را وارد نمیایید.");
    }
}