import {defineStore} from "pinia";

export const informerStores = defineStore("informer", {
    id: "informer",
    state: () => {
        return {
            type2: "--error",
            data: ""
        }
    },
    getters: {
        get() {
            return this.data;
        },
        type() {
            return this.type2;
        }
    },
    actions: {
        set(data, type) {
            switch (type) {
                case 'info':
                    this.type2 = "--info"
                    break
                case 'error':
                    this.type2 = "--error"
                    break
                default:
                    this.type2 = "--info"
            }
            this.data = data;
        },
        remove() {
            this.data = "";
        },
    }
});
