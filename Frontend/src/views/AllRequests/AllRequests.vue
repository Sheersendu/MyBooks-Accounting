<template>
    <table class="table table-dark">
        <thead>
            <tr>
                <th scope="col">Request ID</th>
                <th scope="col">Customer ID</th>
                <th scope="col">Task</th>
            </tr>
        </thead>
        <tbody v-for="request in requests">
            <tr>
                <td class="table-light"><a v-bind:href="'request/'+request.requestID">{{ request.requestID }}</a></td>
                <td class="table-light">{{ request.customerId }}</td>
                <td class="table-light">{{ request.task }}</td>
            </tr>
        </tbody>
    </table>
</template>
<script>
import demo from '../../assets/demo.json';
export default {
    data() {
        return {
            requests: demo
        }
    }
}

</script>
<style>
tr a {
    color: inherit;
    text-decoration: inherit;
}
</style>