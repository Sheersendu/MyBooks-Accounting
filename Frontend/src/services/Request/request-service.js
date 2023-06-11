import { backendRequest } from "../base-service";

const getAllRequests = async() =>{
    const response = await backendRequest('request', {});
    return response;
}
export { getAllRequests};