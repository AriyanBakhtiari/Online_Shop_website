import { getRequest, postRequest } from "./apiCall.js";

window.onload = partiaViewManger()
setTimeout(getUserInfo, 1 * 100);
setTimeout(getOrderCount, 1 * 100);

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

async function getOrderCount() {
    const res = await getRequest("Order");
    analyseOrderCount(res);
}
function analyseOrderCount(res) {
    const orderIcon = document.getElementById("order-count-badge");
    if (res.status == 200) {
        orderIcon.innerText = res.data.productCount;
    }
    else {
        orderIcon.innerText = 0;
    }
}

//helper
