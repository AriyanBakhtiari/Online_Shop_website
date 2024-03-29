const form = document.getElementsByTagName("form");
const email1 = document.getElementById("InputEmail1");
const email1error = email1.nextElementSibling;

const emailRegExp =
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

window.addEventListener("load", () => {
    const isValid = email1.value.length === 0 || emailRegExp.test(email1.value);
    email1.className = isValid ? "form-control valid" : "form-control invalid";
});

email1.addEventListener("input", () => {
    const isValid = email1.value.length === 0 || emailRegExp.test(email1.value);
    if (isValid) {
        email1.className = "form-control valid";
        email1error.textContent = "";
        email1error.style.display = "none";
    } else {
        email1.className = "form-control invalid";
        email1error.style.display = "none";
    }
});

const email2 = document.getElementById("InputEmail2");
const email2error = email2.nextElementSibling;

window.addEventListener("load", () => {
    // Here, we test if the field is empty (remember, the field is not required)
    // If it is not, we check if its content is a well-formed email address.
    const isValid = email2.value.length === 0 || emailRegExp.test(email2.value);
    email2.className = isValid ? "form-control valid" : "form-control invalid";
});

email2.addEventListener("input", () => {
    const isValid = email2.value.length === 0 || emailRegExp.test(email2.value);
    if (isValid) {
        email2.className = "form-control valid";
        email2error.textContent = "";
        email2error.style.display = "none";
    } else {
        email2.className = "form-control invalid";
        email2error.style.display = "none";
    }
});


const password2 = document.getElementById("InputPassword2");
const password2error = password2.nextElementSibling;

const passwordRegext = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;

window.addEventListener("load", () => {
    // Here, we test if the field is empty (remember, the field is not required)
    // If it is not, we check if its content is a well-formed email address.
    const isValid = password2.value.length === 0 || passwordRegext.test(password2.value);
    password2.className = isValid ? "form-control valid" : "form-control invalid";
});

password2.addEventListener("input", () => {
    const isValid = password2.value.length === 0 || passwordRegext.test(password2.value);
    if (isValid) {
        password2.className = "form-control valid";
        password2error.textContent = "";
        password2error.style.display = "none";
    } else {
        password2.className = "form-control invalid";
        password2error.style.display = "none";
    }
});

const password2Repeat = document.getElementById("InputPassword2-repeat");
const password2Repeaterror = password2Repeat.nextElementSibling;

window.addEventListener("load", () => {
    // Here, we test if the field is empty (remember, the field is not required)
    // If it is not, we check if its content is a well-formed email address.
    const isValid = password2Repeat.value.length === 0 || password2Repeat.value == password2.value;
    password2Repeat.className = isValid ? "form-control valid" : "form-control invalid";
});

password2Repeat.addEventListener("input", () => {
    const isValid = password2Repeat.value.length === 0 || password2Repeat.value == password2.value;
    if (isValid) {
        password2Repeat.className = "form-control valid";
        password2Repeaterror.textContent = "";
        password2Repeaterror.style.display = "none";
    } else {
        password2Repeat.className = "form-control invalid";
        password2Repeaterror.style.display = "none";
    }
});

const Name = document.getElementById("inputName");
const Nameerror = Name.nextElementSibling;

window.addEventListener("load", () => {
    // Here, we test if the field is empty (remember, the field is not required)
    // If it is not, we check if its content is a well-formed email address.
    const isValid = Name.value.length === 0;
    Name.className = isValid ? "form-control valid" : "form-control invalid";
});

Name.addEventListener("input", () => {
    const isValid = Name.value.length > 2;
    if (isValid) {
        Name.className = "form-control valid";
        Nameerror.textContent = "";
        Nameerror.style.display = "none";
    } else {
        Name.className = "form-control invalid";
        Nameerror.style.display = "none";
    }
});


const Family = document.getElementById("InputFamily");
const Familyerror = Family.nextElementSibling;

window.addEventListener("load", () => {
    // Here, we test if the field is empty (remember, the field is not required)
    // If it is not, we check if its content is a well-formed email address.
    const isValid = Family.value.length === 0;
    Family.className = isValid ? "form-control valid" : "form-control invalid";
});

Family.addEventListener("input", () => {
    const isValid = Family.value.length > 2;
    if (isValid) {
        Family.className = "form-control valid";
        Familyerror.textContent = "";
        Familyerror.style.display = "none";
    } else {
        Family.className = "form-control invalid";
        Familyerror.style.display = "none";
    }
});


function loginValidation() {
    const email = form[0].elements.InputEmail1;
    const emailerror = email.nextElementSibling;
    let isValid = emailRegExp.test(email.value);
    if (!isValid) {
        email.className = "form-control invalid";
        emailerror.textContent = "◉ " + "ایمیل وارد شده معتبر نمیباشد.";
        emailerror.style.display = "block";
        return false;
    } else {
        email.className = "form-control valid";
        emailerror.textContent = "";
        emailerror.style.display = "none";
    }
    return true;
}

function signUpValidation() {
    let isValid = emailRegExp.test(email2.value);
    if (!isValid) {
        email2.className = "form-control invalid";
        email2error.textContent = "◉ " + "ایمیل وارد شده معتبر نمیباشد.";
        email2error.style.display = "block";
        return false;
    } else {
        email2.className = "form-control valid";
        email2error.textContent = "";
        email2error.style.display = "none";
    }


    isValid = passwordRegext.test(password2.value);
    if (!isValid) {
        if (password2.value.length < 8) {
            password2.className = "form-control invalid";
            password2error.textContent = "◉ " + "رمز عبور باید حداقل 8 رقم باشد.";
            password2error.style.display = "block";
        }
        else {
            password2.className = "form-control invalid";
            password2error.textContent = "◉ " + "رمز عبور وارد شده معتبر نمیباشد";
            password2error.style.display = "block";
        }
        return false;
    } else {
        password2.className = "form-control valid";
        password2error.textContent = "";
        password2error.style.display = "none";
    }

    isValid = password2.value.length === 0 || password2Repeat.value == password2.value;
    if (!isValid) {
        password2Repeat.className = "form-control invalid";
        password2Repeaterror.textContent = "◉ " + "تکرار رمز عبور یکسان نمیباشد";
        password2Repeaterror.style.display = "block";
        return false;

    } else {
        password2Repeat.className = "form-control valid";
        password2Repeaterror.textContent = "";
        password2Repeaterror.style.display = "none";
    }

    isValid = Name.value.length > 2;
    if (!isValid) {
        Name.className = "form-control invalid";
        Nameerror.textContent = "◉ " + "نام را وارد نمایید.";
        Nameerror.style.display = "block";
        return false;
    } else {
        Name.className = "form-control valid";
        Nameerror.textContent = "";
        Nameerror.style.display = "none";
    }


    isValid = Family.value.length > 2;
    if (!isValid) {
        Family.className = "form-control invalid";
        Familyerror.textContent = "◉ " + "نام خانوادگی را وارد نمایید.";
        Familyerror.style.display = "block";
        return false;

    } else {
        Family.className = "form-control valid";
        Familyerror.textContent = "";
        Familyerror.style.display = "none";
    }

    return true;
}

export { loginValidation, signUpValidation };