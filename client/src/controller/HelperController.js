import {reactive, ref} from 'vue';
import {AuthorizeRepository} from "./../repositorys/AuthorizeRepository";
import {JwtResponseModel} from "./../models/JwtResponseModel";
import { useRouter, useRoute } from 'vue-router'
import {OrganizationRepository} from "../repositorys/OrganizationRepository.js";
import {ContractRepository} from "../repositorys/ContractRepository.js";

export class HelperController {
    type = 'create';
    route  = useRoute();
    router = useRouter();
    
    constructor(type, id = 0) {
        console.log(type, id);
        switch (type) {
            case 'read':
                this.read(id);
                break;
            case 'update':
                this.read(id);
                break;
            case 'create':
                break;
            case 'delete':
                this.read(id);
                this.alertDelete(id);
                break;
            case 'export':
                break;
        }
        this.type = type;
    }
    
    async load() {}

    async read(id) {}

    async create() {}
    
    async update() {}

    async delete() {}

    async sendData() {
        switch (this.type) {
            case 'read':
                break;
            case 'update':
                this.update();
                break;
            case 'create':
                this.create();
                break;
        }
    }

    alertDelete(id) {
        const result = confirm("Удалить выбранную карточку?");
        if (result) {
            this.delete(id);
        }
    }
    
    disableStatus() {
        return this.type === 'read' || this.type === 'delete';
    }
}