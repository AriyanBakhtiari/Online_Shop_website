
//const baseURL = "http://zhatis.com/";
const baseURL = "http://localhost:44373/";


function postRequest(serviceName, body) {
    const config = {
        withCredentials: false,
        headers: {
            "Content-Type": "application/json",
            "Athentication": localStorage.getItem("Token")
        }
    }
    const axiosInstance = axios.create({ baseURL });
    let data;
    let status;
    return axiosInstance.post(serviceName, body, config)
        .then(function (response) {
            data = response.data;
            status = response.status;
        }).catch(function (error) {
            data = error.response.data;
            status = error.response.status;
        }).then(function () {
            return { data, status };
        });
}

function getRequest(serviceName) {
    let data;
    let status;

    const axiosInstance = axios.create({ baseURL });
    return axiosInstance.get(serviceName)
        .then(function (response) {
            data = response.data;
            status = response.status;
        }).catch(function () {
            data = response.data;
            status = response.status;
        }).then(function () {
            return { data, status };
        });
}


export { postRequest, getRequest };