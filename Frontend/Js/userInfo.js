import { getRequest, postRequest } from './apicall.js';


window.onload = getUserInfo();
async function getUserInfo() {
    const res = await getRequest("User");
    analyseUserInfo(res);
}

async function analyseUserInfo(res) {
    try {

        if (res.status == 200) {
            const userInfoDetailElement = document.getElementById("user-info-detail");
            const userInfoElement = document.getElementById("user-info");

            let userInfoDetailConponent = await (await fetch("ComponentView/UserInfoDetail.html")).text();
            let userInfoConponent = await (await fetch("ComponentView/UserInfo.html")).text();

            userInfoConponent = userInfoConponent
                .replace("##Name##", res.data.firstName)
                .replace("##Wallet##", res.data.wallet)

            userInfoDetailConponent = userInfoDetailConponent
                .replace("##FirstName##",res.data.firstName)
                .replace("##LastName##", res.data.lastName)
                .replace("##Email##", res.data.email)
                .replace("##BirthDate##", res.data.birthDate)
                .replace("##Gender##", res.data.gender)
                .replace("##Address##", res.data.address)
                .replace("##ZipCode##", res.data.zipCode)
                .replace("##MobileNumber##", res.data.mobileNumber)
                .replace("##NationalId##", res.data.nationalId)

            
            userInfoDetailElement.insertAdjacentHTML("afterbegin", userInfoDetailConponent);
            userInfoElement.insertAdjacentHTML("afterbegin", userInfoConponent);
        }
        else {
            let icon = document.createElement("i");
            icon.classList = "fa fa-exclamation-triangle fa-6x error-icon middle";
            document.getElementById("user-info-detail").appendChild(icon);
        }
    }
    catch {
        let icon = document.createElement("i");
        icon.classList = "fa fa-exclamation-triangle fa-6x error-icon middle";
        document.getElementById("user-info-detail").appendChild(icon);
    }
}






const sideButtonElement = document.querySelectorAll(".side-button");
sideButtonElement.forEach(button => {
    button.addEventListener("click", function (event) {
        sideButtonElement.forEach(button => {
            button.classList.remove("list-group-item-dark");
        })
        button.classList.add("list-group-item-dark");
    });
});

