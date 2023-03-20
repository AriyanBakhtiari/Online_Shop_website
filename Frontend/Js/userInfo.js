import { getRequest, postRequest } from './apicall.js';

window.onload = getUserInfo();
window.onload = getUserOrderList();

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
                .replace("##FirstName##", res.data.firstName)
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

async function getUserOrderList() {
    const res = await getRequest("Order");
    analyseUserOrderList(res);
}
async function analyseUserOrderList(res) {
    if (res.status == 200) {
        var orderListComponent = await (await fetch("ComponentView/userOrderList.html")).text();
        var orderListElement = document.getElementById("user-order-list");

        var tbody = document.createElement("tbody");
        for (let i = 0; i < res.data.productCount; i++) {
            var orderDetail = res.data.orderDetail[i];
            var tr = document.createElement("tr");
            tr.classList = "align-middle-table";

            var td1 = document.createElement("td");
            td1.classList = "orderlist-image";

            var image = document.createElement("img");
            image.classList = "orderlist-image";
            image.src = orderDetail.productDetail.imagePath;
            image.alt = "Image"
            td1.appendChild(image);

            var td2 = document.createElement("td");
            td2.innerText = orderDetail.productDetail.name;

            var td3 = document.createElement("td");
            td3.innerText = orderDetail.productDetail.price;

            var td4 = document.createElement("td");
            td4.innerText = orderDetail.count;

            var td5 = document.createElement("td");
            td5.innerText = orderDetail.price;

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);
            tr.appendChild(td4);
            tr.appendChild(td5);

            tbody.appendChild(tr);
        }
        orderListComponent = orderListComponent
            .replace("##body##", tbody.innerHTML)
            .replace("##TotalPrice##", res.data.totalPrice)

        orderListElement.insertAdjacentHTML("afterbegin", orderListComponent);
    }
    else {
    }
}

document.getElementById("edit-user-form").addEventListener("submit", function () {
    event.preventDefault();
    editUserInfoPostRequst(this.elements);
});

async function editUserInfoPostRequst(formElements) {
    if (formElements.inputBirthdateYear.value == "" || formElements.inputBirthdateMonth.value == "" || formElements.inputBirthdateDay.value == "") {
        var birthDate = "";
    } else {
        var birthDate = `${formElements.inputBirthdateYear.value}/${formElements.inputBirthdateMonth.value}/${formElements.inputBirthdateDay.value}`
    }
    const res = await postRequest("User", {
        firstName: formElements.inputName.value,
        lastName: formElements.inputFamily.value,
        nationalId: formElements.inputNationalID.value,
        birthDate: birthDate,
        address: formElements.InputAddress.value,
        gender: formElements.inputSex.selectedIndex,
        zapCode: formElements.inputZipCode.value,
        mobileNumber: formElements.InputMobileNumber.value
    })
    if (res.status == 200) {
        alert("درخواست با موفقیت انجام شد.");
        location.reload();
    }
    else {
        alert(res.data.errorMessage);
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

