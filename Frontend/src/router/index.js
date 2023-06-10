import { createWebHistory, createRouter } from "vue-router";
import dashboard from "@/views/Dashboard/UserDashboard.vue";
import NotFound from "@/views/NotFound/NotFound.vue"
import Login from "@/views/Login/SigninLogin.vue"
import AllRequests from "@/views/AllRequests/AllRequests.vue"
import QueuedRequests from "@/views/QueuedRequests/QueuedRequests.vue"
import CustomerRequest from "@/views/CustomerRequest/CustomerRequest.vue"

const routes = [
    {
        path: '/',
        redirect: {
            name: "login"
        }
    },
    {
        path: "/login",
        name: "login",
        component: Login,
    },
    {
        path: "/all-requests",
        name: "all-requests",
        component: AllRequests
    },
    {
        path: "/all-queued-requests",
        name: "all-queued-requests",
        component: QueuedRequests
    },
    {
        path: "/dashboard",
        name: "dashboard",
        component: dashboard,
    },
    {
        path: "/requests",
        name: "customer-requests",
        component: CustomerRequest,
    },
    {
        path: "/:catchAll(.*)",
        component: NotFound,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;