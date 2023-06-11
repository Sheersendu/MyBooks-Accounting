import { backendRequest } from "../base-service";
const getCustomerRequests = async(custId) =>{
    const response = await backendRequest('customer/requests', {}, 'GET',{'custId':custId});
    return response;
}
export { getCustomerRequests };