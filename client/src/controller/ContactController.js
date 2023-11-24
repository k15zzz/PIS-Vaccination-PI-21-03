import {reactive, ref} from 'vue';
import {AuthorizeRepository} from "./../repositorys/AuthorizeRepository";
import {JwtResponseModel} from "./../models/JwtResponseModel";
import { useRouter, useRoute } from 'vue-router'
import {OrganizationRepository} from "../repositorys/OrganizationRepository.js";
import {ContractRepository} from "../repositorys/ContractRepository.js";
import {HelperController} from "./HelperController.js";
import {AnimalRepository} from "../repositorys/AnimalRepository.js";

export class ContactController extends HelperController {
    backLink = "/contact-registry"
    
    value = reactive({
        id: null,
        number: null,
        startDate: null,
        endDate: null,
        executor: null,
        client: null
    });
    organizationList =  reactive([]);

    constructor(type, id = 0) {
        super(type, id);
    }

    async read(id) {
        const model = await ContractRepository.get(id);
        this.value.id = model.id;
        this.value.number = model.number;
        this.value.startDate = model.startDate;
        this.value.endDate = model.endDate;
        this.value.executor = {
            id: model.fkExecutor,
            fullName: model.executor,
        };
        this.value.client = {
            id: model.fkClient,
            fullName: model.client,
        };
    }
    
    async load() {
        this.organizationList.push(...await OrganizationRepository.list());
    }

    async update() {
        let resp = await ContractRepository.update(
            this.value.id,
            this.value.number,
            this.value.startDate,
            this.value.endDate,
            this.value.executor.id,
            this.value.client.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }

    async delete(id) {
        let resp = await ContractRepository.delete(id);
        if (resp.ok) {
            this.router.push(this.backLink);
        }
    }
    
    async create() {
        let resp = await ContractRepository.create(
            this.value.number,
            this.value.startDate,
            this.value.endDate,
            this.value.executor.id,
            this.value.client.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }
}