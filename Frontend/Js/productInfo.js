import { getRequest, postRequest } from "./apiCall.js";

setTimeout(getProductDetail, 1);
async function getProductDetail() {
    const urlParams = new URLSearchParams(window.location.search);
    const myParam = urlParams.get('id');

    const res = await getRequest("Products/Id/" + myParam);
    await analyzeProductDetail(res);

    const form = document.getElementById("add-product-form");

    form.addEventListener("submit", function (event) {
        event.preventDefault();
        addProduct(this.elements);
    });
}
async function analyzeProductDetail(res) {
    try {
        const navbarElement = document.getElementById("product-detail-body");
        navbarElement.innerHTML = "";
        if (res.status == 200) {
            let productDeatilComponent = await (await fetch("ComponentView/ProductDetail.html")).text();

            productDeatilComponent = productDeatilComponent
                .replace("##Name##", res.data.name)
                .replace("##Description##", res.data.description)
                .replace("##Image##", res.data.imagePath)
                .replace("##Price##", res.data.price)
                .replace("##Category##", res.data.categoryName)

            navbarElement.insertAdjacentHTML("beforeend", productDeatilComponent);

            let script = document.createElement('script');
            script.src = "./Resource/quantityInput/quantityInput.js";
            script.setAttribute("type", "module")
            document.body.append(script);
        }
        else {
            let icon = document.createElement("i");
            icon.classList = "fa fa-exclamation-triangle fa-6x error-icon middle";
            navbarElement.appendChild(icon);
            alert("محصولی یافت نشد.");
        }
    } catch (error) {
        let icon = document.createElement("i");
        icon.classList = "fa fa-exclamation-triangle fa-6x error-icon middle";
        document.getElementById("product-detail-body").appendChild(icon);
    }
}

async function addProduct(element) {
    const urlParams = new URLSearchParams(window.location.search)
    const myParam = urlParams.get('id');
    const res = await postRequest("Order/AddProduct", {
        productId: myParam,
        quantity: element.quantity.value
    })
    analyseAddProduct(res);
}
function analyseAddProduct(res) {
    if (res.status == 200) {
        location.reload();
    }
    else {
        alert(res.data.errorMessage);
    }
}