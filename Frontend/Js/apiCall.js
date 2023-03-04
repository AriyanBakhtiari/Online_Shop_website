//import axios from "";

const baseURL = "http://zhatis.com/";

// console.log(postRequest("CurrencyInquiry", body));
function postRequest(serviceName, body = {}) {
    const axiosInstance = axios.create({ baseURL });
    return axiosInstance.post(serviceName, body)
        .then(function (response) {
            console.log(response.data);
            return response.data;
        });
}

function getRequest(serviceName) {
    const axiosInstance = axios.create({ baseURL });
    return axiosInstance.get(serviceName)
        .then(function (response) {
            console.log(response.data);
            return response.data;
        });
}


export { postRequest, getRequest };