<template>
    <table class="table table-dark ml-3 mr-3">
        <thead>
            <tr>
                <th scope="col-6">Request ID</th>
                <th scope="col-6">Completed</th>
            </tr>
        </thead>
        <tbody>
            <tr 
            v-for="request in requests"
            :key="request.id">
                <td class="table-light"><router-link class="nav-link" :to="'/request/' + request.Req_ID">{{
                    request.Req_ID }}</router-link></td>
                <td class="table-light">{{ request.Req_IsCompleted }}</td>
            </tr>
        </tbody>
    </table>
</template>
<script>
import { getAllQueuedRequests } from '@/services/Expert';
export default {
    data() {
        return {
            requests : [],
            expertId : 2
        }
    },
    async mounted () {
        this.requests = await getAllQueuedRequests(this.expertId);
    }
}
</script>
<style>
tr a {
    color: inherit;
    text-decoration: inherit;
}
</style>