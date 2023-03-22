import { createStore } from "vuex";

export default createStore({
    state: {
        requestList: [
            {
                "requestID": "Store Request1",
                "customerId": "C1",
                "task": "Task1"
            },
            {
                "requestID": "Store Request2",
                "customerId": "C1",
                "task": "Task2"
            },
            {
                "requestID": "Store Request3",
                "customerId": "C2",
                "task": "Task1"
            },
            {
                "requestID": "Store Request4",
                "customerId": "C2",
                "task": "Task3"
            }
        ],
        isUserAuthenticated: false
    },
    mutations: {
        addRequest(state, request) {
            state.requestList.push(request);
        },
        authenticateUser(state) {
            state.isUserAuthenticated = true;
        }
    },
    actions: {
        addRequestAsync({ commit }, request) {
            commit('addRequest', request);
        },
        authenticateUser({ commit }) {
            commit('authenticateUser')
        }
    },
    getters: {
        getRequestList(state) {
            return state.requestList;
        },
        isAuthenticated(state) {
            return state.isUserAuthenticated;
        }
    }
})