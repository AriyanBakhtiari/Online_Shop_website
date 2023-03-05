import { loginValidation } from "./loginvalidation.js";
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

        if (!validation) {
            return false;
        }
        loginrequest(this.elements);
    });
});

async function loginrequest(formElements) {
    var res = await postRequest("Login",
        {
            email: formElements.InputEmail1.value,
            password: formElements.InputPassword1.value
        });
    if (!res) {
        return false;
    }
    localStorage.setItem("Token", "Bearer " + res);
    window.location.href = "http://127.0.0.1:5500/";
}
