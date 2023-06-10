import { createStore } from "vuex";

export default createStore({
    state: {
        isUserAuthenticated: false,
        isExpert : false
    },
    mutations: {
        authenticateUser(state) {
            state.isUserAuthenticated = true;
        },
        isExpert(state, isExpert) {
            state.isExpert = isExpert;
        }
    },
    actions: {
        authenticateUser({ commit }) {
            commit('authenticateUser')
        },
        isExpert({commit}, isExpert) {
            commit('isExpert', isExpert);
        }
    },
    getters: {
        isAuthenticated(state) {
            return state.isUserAuthenticated;
        },
        getIsExpert(state) {
            return state.isExpert;
        }
    }
})