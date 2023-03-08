import { getRequest, postRequest } from "./apiCall.js";

window.onload = partiaViewManger()
setTimeout(getUserInfo, 5 * 100);

async function partiaViewManger() {
    var includes = document.querySelectorAll('[data-include]')
    includes.forEach(
        async element => {
            const path = 'PartialViews/' + element.getAttribute("data-include") + '.html';
            const html = await (await fetch(path)).text();
            element.insertAdjacentHTML("afterbegin", html)
        }
    )
}
async function getUserInfo() {
    const res = await getRequest('User');
    analyseUserInfo(res);
}
async function analyseUserInfo(res) {
    const navbarElement = document.getElementById("left-navbar");
    if (res.status == 200) {
        let userInfoComponent = await (await fetch("ComponentView/UserInfoDropDown.html")).text();

        userInfoComponent = userInfoComponent
            .replace("##Name##", res.data.firstName == null ? res.data.email : res.data.firstName)
            .replace("##Wallet##", res.data.wallet)

        navbarElement.removeChild(navbarElement.lastElementChild);
        navbarElement.insertAdjacentHTML("beforeend", userInfoComponent);

    }
    else {
        localStorage.removeItem("Token");
    }
}

//helper
function toFarsiNumber(n) {

    const farsiDigits = ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'];
    let num = "";
    for (let i = 0; i < n.length; i++) {
        if (n[i] == "0") {
            num += farsiDigits[0];
        }
        else if (n[i] == "1") {
            num += farsiDigits[1];
        }
        else if (n[i] == "2") {
            num += farsiDigits[2];
        }
        else if (n[i] == "3") {
            num += farsiDigits[3];
        }
        else if (n[i] == "4") {
            num += farsiDigits[4];
        }
        else if (n[i] == "5") {
            num += farsiDigits[5];
        }
        else if (n[i] == "6") {
            num += farsiDigits[6];
        }
        else if (n[i] == "7") {
            num += farsiDigits[7];
        }
        else if (n[i] == "8") {
            num += farsiDigits[8];
        }
        else if (n[i] == "9") {
            num += farsiDigits[9];
        }
        else {
            num += n[i]
        }
    }
    return num;
}
function toPersianDate(date) {
    const datetime = new Date(date);
    const persianDate = datetime.toLocaleDateString('fa-IR');
    return persianDate;
}