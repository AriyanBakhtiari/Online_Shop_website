const basicUrl = "http://webcrawler.inquiry.ayantech.ir/WebServices/Core.svc/";
body = {}

console.log(postRequest("CurrencyInquiry", body));

function postRequest(serviceName, body) {
    const axios = require("./node_modules/axios/dist/node/axios.cjs");
    return axios.post(basicUrl + serviceName, body)
        .then(function (response) {
            // if (response.Status.Code === "G00000")
            console.log(test);
        })
}