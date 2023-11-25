import {defineStore} from "pinia";

const errorGeter = (errorNum, error) => {
    switch (errorNum) {
        case 500: 
            return "Что-то пошло не так. Измените параметры запроса и попробуйте снова"
        case 400:
            return "Неверный запрос. Измените параметры запроса и попробуйте снова"
        default:
            return error;
    }
}

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
                    this.type2 = "--info";
                    this.data = data;
                    break
                case 'error':
                    this.type2 = "--error";
                    this.data = errorGeter(data.response.status, data);
                    break
                default:
                    this.type2 = "--info";
                    this.data = data;
                    break;
            }
        },
        remove() {
            this.data = "";
        },
    }
});
