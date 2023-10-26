import {reactive, ref} from 'vue';
import {AuthorizeRepository} from "./../repositorys/AuthorizeRepository";
import {JwtResponseModel} from "./../models/JwtResponseModel";
import { useRouter, useRoute } from 'vue-router'

export class AuthorizeController {
    value = reactive({
        login: "",
        password: "",
        error: ""
    });
    
    async auth() {
        let jwtResponseModel = await AuthorizeRepository.auth(this.value.login, this.value.password);

        if (jwtResponseModel.accessToken == null && jwtResponseModel.userId == null) {
            this.value.error = "Что-то пошло не так"
            return;
        }

        jwtResponseModel.saveLocalStorage();
        window.location = "/";
    }

    static out() {
        localStorage.clear();
        window.location = "/";
    }
}