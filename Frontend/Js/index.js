import { getRequest, postRequest } from "./apiCall.js";

// window.onload = CurrencyApiCall();
// window.onload = CryptoCurrencyApiCall();
// window.onload = GoldCurrencyApiCall();
window.onload = getProductList();

async function getProductList() {
    const res = await getRequest('Products');
    createProductCart(res);
}
function createProductCart(res) {
    const element = document.getElementById("product-row-list");

    for (let i = 0; i < res.length; i++) {

        const div = document.createElement("div");
        div.classList = "col-3";

        const div2 = document.createElement("div");
        div2.classList = "card border-dark mb-3 card text-center";

        const image = document.createElement("img");
        image.setAttribute("src", res[i].imagePath);
        image.setAttribute("width", "250");
        image.setAttribute("height", "250");
        image.classList = "card-img-top";

        const div3 = document.createElement("div");
        div3.classList = "card-body";

        const title = document.createElement("h6");
        title.classList = "card-title";
        title.innerText = res[i].name;

        const p = document.createElement("p");
        p.classList = "card-text";
        const price = document.createElement("span");
        price.classList = "badge badge-light";
        price.innerText = res[i].price + "تومان";
        p.appendChild(price);

        const link = document.createElement("a");
        link.classList = "btn btn-dark";
        link.setAttribute("href", "./product/" + res[i].id)
        link.innerText = "جزییات محصول";

        div3.appendChild(title);
        div3.appendChild(p);
        div3.appendChild(link);

        div2.appendChild(image);
        div2.appendChild(div3);

        div.appendChild(div2);

        element.appendChild(div);
    }

}


async function CurrencyApiCall() {
    const res = await postRequest('CurrencyInquiry');
    createCurrencySummaryTable(res);
    createCurrencyTable(res);
}
function createCurrencySummaryTable(res) {
    const element = document.getElementById("currency-list-group");
    const tbl = document.createElement("table");
    const tblBody = document.createElement("tbody");
    const tblHead = document.createElement("thead");
    const rowHeader = document.createElement("tr");

    const th1 = document.createElement("th");
    th1.textContent = "عنوان";
    rowHeader.appendChild(th1);

    const th2 = document.createElement("th");
    th2.textContent = "قیمت";
    th2.classList = "text-center";
    rowHeader.appendChild(th2);

    tblHead.appendChild(rowHeader)

    for (let i = 0; i < 3; i++) {
        const row = document.createElement("tr");

        const td1 = document.createElement("td");
        const image = document.createElement("img");
        image.setAttribute("src", res.CurrencyInquiryDataList[i].Icon);
        image.className = "avatar-currency";
        td1.appendChild(image);

        const name = document.createElement("span");
        name.textContent = res.CurrencyInquiryDataList[i].ShowName;
        td1.appendChild(name);
        row.appendChild(td1);


        const price = document.createElement("td");
        price.className = "persian-num text-center";
        price.textContent = toFarsiNumber(res.CurrencyInquiryDataList[i].Price);
        row.appendChild(price);

        tblBody.appendChild(row);
    }
    const detailRow = document.createElement("tr");
    const td = document.createElement("td");
    td.setAttribute("colspan", "2");
    td.className = "text-center";
    const detailRowButton = document.createElement("button");
    detailRowButton.className = "btn btn-secondary btn-block";
    detailRowButton.setAttribute("data-toggle", "modal");
    detailRowButton.setAttribute("data-target", "#currencyModel");
    detailRowButton.textContent = "جزییات بیشتر"
    td.appendChild(detailRowButton);
    detailRow.appendChild(td);
    tblBody.appendChild(detailRow);

    tbl.appendChild(tblHead);
    tbl.appendChild(tblBody);
    tbl.classList = "table table-sm";

    element.innerHTML = "";
    element.appendChild(tbl);
}
function createCurrencyTable(res) {
    const element = document.getElementById("currency-list-group-table");
    const tbl = document.createElement("table");
    const tblBody = document.createElement("tbody");
    const tblHead = document.createElement("thead");
    const tbl2 = document.createElement("table");
    const tblBody2 = document.createElement("tbody");
    const tblHead2 = document.createElement("thead");

    const rowHeader = document.createElement("tr");

    const th1 = document.createElement("th");
    th1.textContent = "عنوان";
    rowHeader.appendChild(th1);

    const th2 = document.createElement("th");
    th2.textContent = "قیمت زنده";
    rowHeader.appendChild(th2);

    const th3 = document.createElement("th");
    th3.textContent = "تغییر";
    rowHeader.appendChild(th3);

    const th4 = document.createElement("th");
    th4.textContent = "کمترین قیمت";
    rowHeader.appendChild(th4);

    const th5 = document.createElement("th");
    th5.textContent = "بیشترین قیمت";
    rowHeader.appendChild(th5);

    const th6 = document.createElement("th");
    th6.textContent = "زمان";
    rowHeader.appendChild(th6);


    tblHead.appendChild(rowHeader)

    for (let i = 0; i < res.CurrencyInquiryDataList.length; i++) {
        if (i % 2 == 0) {
            const row = document.createElement("tr");

            const td1 = document.createElement("td");
            const image = document.createElement("img");
            image.setAttribute("src", res.CurrencyInquiryDataList[i].Icon);
            image.className = "avatar-currency";
            td1.appendChild(image);

            const name = document.createElement("span");
            name.textContent = res.CurrencyInquiryDataList[i].ShowName;
            td1.appendChild(name);
            row.appendChild(td1);

            const price = document.createElement("td");
            price.textContent = toFarsiNumber(res.CurrencyInquiryDataList[i].Price);
            row.appendChild(price);

            const changePrice = document.createElement("td");
            changePrice.textContent = res.CurrencyInquiryDataList[i].Change24H;
            row.appendChild(changePrice);

            const lowestPrice = document.createElement("td");
            lowestPrice.textContent = res.CurrencyInquiryDataList[i].LowestPrice;
            row.appendChild(lowestPrice);

            const highestPrice = document.createElement("td");
            highestPrice.textContent = res.CurrencyInquiryDataList[i].HighestPrice;
            row.appendChild(highestPrice);

            const lastUpdate = document.createElement("td");
            lastUpdate.textContent = toPersianDate(res.CurrencyInquiryDataList[i].LastUpdate);
            row.appendChild(lastUpdate);

            tblBody.appendChild(row);
        }
        else {
            const row2 = document.createElement("tr");

            const td1_2 = document.createElement("td");
            const image2 = document.createElement("img");
            image2.setAttribute("src", res.CurrencyInquiryDataList[i].Icon);
            image2.className = "avatar-currency";
            td1_2.appendChild(image2);

            const name2 = document.createElement("span");
            name2.textContent = res.CurrencyInquiryDataList[i].ShowName;
            td1_2.appendChild(name2);
            row2.appendChild(td1_2);

            const price2 = document.createElement("td");
            price2.textContent = toFarsiNumber(res.CurrencyInquiryDataList[i].Price);
            row2.appendChild(price2);

            const changePrice2 = document.createElement("td");
            changePrice2.textContent = res.CurrencyInquiryDataList[i].Change24H;
            row2.appendChild(changePrice2);

            const lowestPrice2 = document.createElement("td");
            lowestPrice2.textContent = res.CurrencyInquiryDataList[i].LowestPrice;
            row2.appendChild(lowestPrice2);

            const highestPrice2 = document.createElement("td");
            highestPrice2.textContent = res.CurrencyInquiryDataList[i].HighestPrice;
            row2.appendChild(highestPrice2);

            const lastUpdate2 = document.createElement("td");
            lastUpdate2.textContent = toPersianDate(res.CurrencyInquiryDataList[i].LastUpdate);
            row2.appendChild(lastUpdate2);

            tblBody2.appendChild(row2);
        }
    }

    tbl.appendChild(tblHead.cloneNode(true));
    tbl.appendChild(tblBody);
    tbl.classList = "table table-striped table-1";

    tbl2.appendChild(tblHead.cloneNode(true));
    tbl2.appendChild(tblBody2);
    tbl2.classList = "table table-striped";

    element.innerHTML = "";
    element.appendChild(tbl);
    element.appendChild(tbl2);

}

async function CryptoCurrencyApiCall() {
    const res = await postRequest('CryptoCurrencyInquiry');
    createcryptoCurrencySummaryTable(res);
    createCryptoCurrencyTable(res);
}
function createcryptoCurrencySummaryTable(res) {
    const element = document.getElementById("crypto-currency-list-group");
    const tbl = document.createElement("table");
    const tblBody = document.createElement("tbody");
    const tblHead = document.createElement("thead");
    const rowHeader = document.createElement("tr");

    const th1 = document.createElement("th");
    th1.textContent = "عنوان";
    rowHeader.appendChild(th1);

    const th2 = document.createElement("th");
    th2.textContent = "قیمت";
    th2.classList = "text-center";
    rowHeader.appendChild(th2);

    tblHead.appendChild(rowHeader)

    for (let i = 0; i < 3; i++) {
        const row = document.createElement("tr");

        const td1 = document.createElement("td");
        const image = document.createElement("img");
        image.setAttribute("src", res.CryptoCurrencyInquiryDataList[i].Icon);
        image.className = "avatar-currency";
        td1.appendChild(image);

        const name = document.createElement("span");
        name.textContent = res.CryptoCurrencyInquiryDataList[i].ShowName;
        td1.appendChild(name);
        row.appendChild(td1);


        const price = document.createElement("td");
        price.className = "persian-num text-center";
        price.textContent = res.CryptoCurrencyInquiryDataList[i].Price;
        row.appendChild(price);

        tblBody.appendChild(row);
    }
    const detailRow = document.createElement("tr");
    const td = document.createElement("td");
    td.setAttribute("colspan", "2");
    td.className = "text-center";
    const detailRowButton = document.createElement("button");
    detailRowButton.className = "btn btn-secondary btn-block";
    detailRowButton.setAttribute("data-toggle", "modal");
    detailRowButton.setAttribute("data-target", "#CryptoCurrencyModel");
    detailRowButton.textContent = "جزییات بیشتر"
    td.appendChild(detailRowButton);
    detailRow.appendChild(td);
    tblBody.appendChild(detailRow);

    tbl.appendChild(tblHead);
    tbl.appendChild(tblBody);
    tbl.classList = "table table-sm";

    element.innerHTML = "";
    element.appendChild(tbl);
}
function createCryptoCurrencyTable(res) {
    const element = document.getElementById("cryptocurrency-list-group-table");
    const tbl = document.createElement("table");
    const tblBody = document.createElement("tbody");
    const tblHead = document.createElement("thead");
    const tbl2 = document.createElement("table");
    const tblBody2 = document.createElement("tbody");
    const tblHead2 = document.createElement("thead");

    const rowHeader = document.createElement("tr");

    const th1 = document.createElement("th");
    th1.textContent = "عنوان";
    rowHeader.appendChild(th1);

    const th2 = document.createElement("th");
    th2.textContent = "قیمت زنده";
    rowHeader.appendChild(th2);

    const th3 = document.createElement("th");
    th3.textContent = "تغییر";
    rowHeader.appendChild(th3);


    const th6 = document.createElement("th");
    th6.textContent = "زمان";
    rowHeader.appendChild(th6);


    tblHead.appendChild(rowHeader)

    for (let i = 0; i < res.CryptoCurrencyInquiryDataList.length; i++) {
        if (i % 2 == 0) {
            const row = document.createElement("tr");

            const td1 = document.createElement("td");
            const image = document.createElement("img");
            image.setAttribute("src", res.CryptoCurrencyInquiryDataList[i].Icon);
            image.className = "avatar-currency";
            td1.appendChild(image);

            const name = document.createElement("span");
            name.textContent = res.CryptoCurrencyInquiryDataList[i].ShowName;
            td1.appendChild(name);
            row.appendChild(td1);

            const price = document.createElement("td");
            price.textContent = toFarsiNumber(res.CryptoCurrencyInquiryDataList[i].Price);
            row.appendChild(price);

            const changePrice = document.createElement("td");
            changePrice.textContent = res.CryptoCurrencyInquiryDataList[i].Change24H;
            row.appendChild(changePrice);


            const lastUpdate = document.createElement("td");
            lastUpdate.textContent = toPersianDate(res.CryptoCurrencyInquiryDataList[i].LastUpdate);
            row.appendChild(lastUpdate);

            tblBody.appendChild(row);
        }
        else {

            const row2 = document.createElement("tr");

            const td1_2 = document.createElement("td");
            const image2 = document.createElement("img");
            image2.setAttribute("src", res.CryptoCurrencyInquiryDataList[i].Icon);
            image2.className = "avatar-currency";
            td1_2.appendChild(image2);

            const name2 = document.createElement("span");
            name2.textContent = res.CryptoCurrencyInquiryDataList[i].ShowName;
            td1_2.appendChild(name2);
            row2.appendChild(td1_2);

            const price2 = document.createElement("td");
            price2.textContent = toFarsiNumber(res.CryptoCurrencyInquiryDataList[i].Price);
            row2.appendChild(price2);

            const changePrice2 = document.createElement("td");
            changePrice2.textContent = res.CryptoCurrencyInquiryDataList[i].Change24H;
            row2.appendChild(changePrice2);

            const lastUpdate2 = document.createElement("td");
            lastUpdate2.textContent = toPersianDate(res.CryptoCurrencyInquiryDataList[i].LastUpdate);
            row2.appendChild(lastUpdate2);

            tblBody2.appendChild(row2);
        }
    }

    tbl.appendChild(tblHead.cloneNode(true));
    tbl.appendChild(tblBody);
    tbl.classList = "table table-striped table-1";

    tbl2.appendChild(tblHead.cloneNode(true));
    tbl2.appendChild(tblBody2);
    tbl2.classList = "table table-striped";

    element.innerHTML = "";
    element.appendChild(tbl);
    element.appendChild(tbl2);

}

async function GoldCurrencyApiCall() {
    const res = await postRequest('GoldPriceInquiry');
    createGoldCurrencySummaryTable(res);
}
function createGoldCurrencySummaryTable(res) {
    const element = document.getElementById("gold-currency-list-group");
    const tbl = document.createElement("table");
    const tblBody = document.createElement("tbody");
    const tblHead = document.createElement("thead");
    const rowHeader = document.createElement("tr");

    const th1 = document.createElement("th");
    th1.textContent = "عنوان";
    rowHeader.appendChild(th1);

    const th2 = document.createElement("th");
    th2.textContent = "قیمت";
    th2.classList = "text-center";
    rowHeader.appendChild(th2);

    tblHead.appendChild(rowHeader)

    for (let i = 0; i < 3; i++) {
        const row = document.createElement("tr");

        const td1 = document.createElement("td");
        const name = document.createElement("span");
        name.textContent = res.GoldPriceInquiryDataList[i].ShowName;
        td1.appendChild(name);
        row.appendChild(td1);


        const price = document.createElement("td");
        price.className = "persian-num text-center";
        price.textContent = toFarsiNumber(res.GoldPriceInquiryDataList[i].Price);
        row.appendChild(price);

        tblBody.appendChild(row);
    }
    const detailRow = document.createElement("tr");
    const td = document.createElement("td");
    td.setAttribute("colspan", "2");
    td.className = "text-center";
    const detailRowButton = document.createElement("button");
    detailRowButton.className = "btn btn-secondary btn-block";
    detailRowButton.setAttribute("data-toggle", "modal");
    detailRowButton.setAttribute("data-target", "#currencyModel");
    detailRowButton.textContent = "جزییات بیشتر"
    td.appendChild(detailRowButton);
    detailRow.appendChild(td);
    tblBody.appendChild(detailRow);

    tbl.appendChild(tblHead);
    tbl.appendChild(tblBody);
    tbl.classList = "table table-sm";

    element.innerHTML = "";
    element.appendChild(tbl);
}
