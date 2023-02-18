

document.getElementById("login-form-button").addEventListener("click",showLoginForm);
document.getElementById("signin-form-button").addEventListener("click",showSignInForm);


function showSignInForm() {
    document.getElementsByClassName("signup-form")[0].classList.remove("active");
    document.getElementsByClassName("login-form")[0].classList.add("active");
};

function showLoginForm() {
    document.getElementsByClassName("signup-form")[0].classList.add("active");
    document.getElementsByClassName("login-form")[0].classList.remove("active");
};