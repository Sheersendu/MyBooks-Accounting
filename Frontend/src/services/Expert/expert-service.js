import { backendRequest } from "../base-service";
const getAllQueuedRequests = async(expertId) =>{
    const response = await backendRequest('expert/requests', {}, 'GET',{'expId':expertId});
    return response;
}
export { getAllQueuedRequests };