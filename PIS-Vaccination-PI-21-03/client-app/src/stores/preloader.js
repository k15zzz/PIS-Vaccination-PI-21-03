import {defineStore} from "pinia";

export const usePreloaderStore = defineStore("preloader", {
    id: "preloader",
    state: () => {
        return {
            valueVisible: false
        }
    },
    getters: {
        get() {
            return this.valueVisible;
        }
    },
    actions: {
        set(value) {
            this.valueVisible = value;
        },
    }
});
