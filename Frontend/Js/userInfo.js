import { getRequest, postRequest } from './apicall.js';

window.onload = getUserInfo();
window.onload = getUserOrderList();
window.onload = getOrderHistory();

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
    await analyseUserOrderList(res);

    document.getElementById("finalize-purchase").addEventListener("click", function () {
        event.preventDefault();
        finalizePurchase();
    });


    const removeButton = document.querySelectorAll(".remove-product")
    removeButton.forEach(button => {
        button.addEventListener("click", function (event) {
            event.preventDefault();
            removeProduct(event);
        });
    })
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

            var td6 = document.createElement("td");
            var button = document.createElement("button");
            button.innerText = "حذف";
            button.setAttribute("href", "#");
            button.classList = "btn btn-light remove-product";
            button.id = orderDetail.id;

            td6.appendChild(button);

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);
            tr.appendChild(td4);
            tr.appendChild(td5);
            tr.appendChild(td6);

            tbody.appendChild(tr);
        }
        orderListComponent = orderListComponent
            .replace("##body##", tbody.innerHTML)
            .replace("##TotalPrice##", res.data.totalPrice)
            .replace("##id##", res.data.id)

        orderListElement.innerHTML = "";
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

async function finalizePurchase() {


    const id = document.getElementsByTagName("table")[0].id;
    const res = await postRequest("Order/FinalizePurchase", {
        orderId: id
    });
    if (res.status == 200) {
        alert("درخواست با موفقیت انجام شد.");
        location.reload();
    }
    else {
        alert(res.data.errorMessage);
    }
}

async function removeProduct(event) {
    const res = await postRequest("Order/RemoveProduct", {
        orderDetailId: event.target.id,
    });
    if (res.status == 200) {
        getUserOrderList();
    }
    else {
        alert(res.data.errorMessage);
    }
}

async function getOrderHistory() {
    const res = await getRequest("Order/OrderHistory");
    await analyseOrderHistory(res);
}
async function analyseOrderHistory(res) {
    if (res.status == 200) {
        let orderHistory = await (await fetch("ComponentView/OrderHistory.html")).text();
        let orderHistoryProduct = await (await fetch("ComponentView/OrderHistoryProduct.html")).text();
        let historyBody = "";
        for (let i = 0; i < res.data.orderList.length; i++) {
            const orderList = res.data.orderList[i];
            let order = orderHistory;
            let product = "";

            for (let i = 0; i < orderList.orderDetailList.length; i++) {
                const orderDetailList = orderList.orderDetailList[i];
                let orderPtoduct = orderHistoryProduct;
                const name = orderDetailList.productName.length > 20 ? orderDetailList.productName.substring(0, 25) + "..." : orderDetailList.productName;
                product += orderPtoduct.replace("##Name##", name)
                    .replace("##Image##", orderDetailList.productImage)
                    .replace("##Price##", orderDetailList.productPrice)
            }

            historyBody += order.replace("##TotalPrice##", orderList.totalPrice)
                .replace("##OrderNum##", orderList.id)
                .replace("##OrderDate##", orderList.finalizeDate)
                .replace("##Product##", product);
        }
        document.getElementById("order-history").insertAdjacentHTML("afterbegin", historyBody);

        var elms = document.getElementsByClassName('splide');
        for (var i = 0; i < elms.length; i++) {
            new Splide(elms[i], {

                direction: 'rtl',
                perPage: 5,
                focus: 'center',
                rewind: true,
                speed: 400,
                perMove: 1,
                pagination: false,
                drag: true,
                autoWidth: true,
                trimSpace: 'move',
            }).mount();
        }
        $('#list-group a:nth-child(3)').tab('show')
    }
    else {
        alert(res.data.errorMessage)
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

