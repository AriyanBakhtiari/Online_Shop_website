//import axios from "";

const baseURL = "http://webcrawler.inquiry.ayantech.ir/WebServices/Core.svc/";

// console.log(postRequest("CurrencyInquiry", body));
export function postRequest(serviceName, body = {}) {
    const axiosInstance = axios.create({ baseURL });
    return axiosInstance.post(serviceName, body)
        .then(function (response) {
            // if (response.Status.Code === "G00000")
            console.log(response.data);
            return response.data.Parameters;
        });
}
