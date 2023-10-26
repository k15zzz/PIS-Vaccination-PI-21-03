import {defineStore} from "pinia";

export const userStore = defineStore("user", {
    id: "user",
    state: () => {
        return {
            loggedIn: false,
            isSubscribed: false
        }
    },
    getters: {
        isAuth() {
            return this.loggedIn;
        }
    },
    actions: {}
});
