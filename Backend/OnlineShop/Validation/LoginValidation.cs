using FluentValidation;
using OnlineShop.ViewModel;

namespace OnlineShop.Validation;

public class LoginValidation : AbstractValidator<LoginModel>
{
    public LoginValidation()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("ایمیل را وارد نمایید.")
            .Matches("^\\S+@\\S+\\.\\S+$")
            .WithMessage("ایمیل وارد شده معتبر نمیباشد.");

        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("لطفا پسورد را وارد نمیایید.")
            .NotEmpty()
            .WithMessage("لطفا پسورد را وارد نمیایید.");
    }
}