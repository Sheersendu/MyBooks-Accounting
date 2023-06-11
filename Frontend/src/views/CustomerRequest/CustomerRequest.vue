<template>
    <table class="table table-light ml-3 mr-3">
        <thead>
            <tr>
                <th scope="col-6">Request ID</th>
                <th scope="col-6">Task ID</th>
                <th scope="col-6">Status</th>
            </tr>
        </thead>
        <tbody>
            <tr 
            v-for="request in requests"
            :key="request.id">
                <td class="table-light">{{ request.Req_Name }}</td>
                <td class="table-light">{{ request.CustReq_TASK_ID }}</td>
                <td class="table-light">{{ request.CustReq_STATUS }}</td>
            </tr>
        </tbody>
    </table>
</template>
<script>
import { getCustomerRequests } from '@/services/Customer';

export default {
    data() {
        return {
            requests : [],
            custId : 1
        }
    },
    async mounted () {
        this.requests = await getCustomerRequests(this.custId);
    }
}
</script>