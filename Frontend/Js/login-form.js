import { loginValidation, signUpValidation } from "./loginvalidation.js";
import { postRequest, getRequest } from "./apiCall.js";

document.getElementById("login-form-button").addEventListener("click", showLoginForm);
document.getElementById("signin-form-button").addEventListener("click", showSignInForm);

function showSignInForm() {
    document.getElementsByClassName("signup-form")[0].classList.remove("active");
    document.getElementsByClassName("login-form")[0].classList.add("active");
};
function showLoginForm() {
    document.getElementsByClassName("signup-form")[0].classList.add("active");
    document.getElementsByClassName("login-form")[0].classList.remove("active");
};

window.addEventListener("load", () => {
    const form = document.getElementsByTagName("form");

    form[0].addEventListener("submit", function () {
        event.preventDefault();

        var validation = loginValidation();
        if (!validation)
            return false;

        loginrequest(this.elements);
    });

    form[1].addEventListener("submit", function () {
        event.preventDefault();
        var validation = signUpValidation();
        if (!validation)
            return false;

        signupRequest(this.elements);
    });
});

async function loginrequest(formElements) {
    try {
        var res = await postRequest("Login",
            {
                email: formElements.InputEmail1.value,
                password: formElements.InputPassword1.value
            });
        if (res.status == 200) {
            localStorage.setItem("Token", "Bearer " + res.data);
            window.location.href = "http://127.0.0.1:5500/";
            return true;
        }
        else {
            alert(res?.data?.errorMessage ?? "متاسفانه مشکلی پیش امده است");
            return false;
        }
    } catch (error) {
        alert(res?.data?.errorMessage ?? "متاسفانه مشکلی پیش امده است");
        return false;
    }
}
async function signupRequest(formElements) {
    try {
        var res = await postRequest("SignUp",
            {
                firstName: formElements.inputName.value,
                lastName: formElements.InputFamily.value,
                email: formElements.InputEmail2.value,
                password: formElements.InputPassword2.value
            });
        if (res.status == 200) {
            localStorage.setItem("Token", "Bearer " + res.data);
            window.location.href = "http://127.0.0.1:5500/";
        }
        else {
            alert(res?.data?.errorMessage ?? "متاسفانه مشکلی پیش امده است");
            return false;
        }
    } catch (error) {
        alert(res?.data?.errorMessage ?? "متاسفانه مشکلی پیش امده است");
        return false;
    }
}