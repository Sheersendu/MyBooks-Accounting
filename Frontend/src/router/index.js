import { createWebHistory, createRouter } from "vue-router";
import dashboard from "@/views/Dashboard/dashboard.vue";
import NotFound from "@/views/NotFound/NotFound.vue"
import Login from "@/views/Login/Login.vue"
import AllRequests from "@/views/AllRequests/AllRequests.vue"
import Request from "@/views/Request/Request.vue"

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
        path: "/dashboard",
        name: "dashboard",
        component: dashboard,
    },
    {
        path: "/request/:requestId",
        name: "request",
        component: Request,
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