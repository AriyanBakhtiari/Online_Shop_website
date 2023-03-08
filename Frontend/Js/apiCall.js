
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

    return axiosInstance.post(serviceName, body, config)
        .then(function (response) {
            return response.data;
        })
        .catch((e) => {
            console.log(e.response);
            if (e.response.status == 404) {
                localStorage.removeItem("Token");
            }
            alert(e.response.data.errorMessage)
            return false;
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