import {reactive, ref} from 'vue';
import {AuthorizeRepository} from "./../repositorys/AuthorizeRepository";
import {JwtResponseModel} from "./../models/JwtResponseModel";
import { useRouter, useRoute } from 'vue-router'
import {AnimalRepository} from "../repositorys/AnimalRepository.js";
import {ContractRepository} from "../repositorys/ContractRepository.js";
import {OrganizationRepository} from "../repositorys/OrganizationRepository.js";
import {HelperController} from "./HelperController.js";

export class OrganizationController extends HelperController {
    backLink = '/organization-registry';
    value = reactive({
        full_name: null,
        inn: null,
        kpp: null,
        address: null,
        type: null,
        legal_entity: false,
        town: null
    });
    townList = reactive([]);

    constructor(type, id = 0) {
        super(type, id);
    }
    
    async read(id) {
        const model = await OrganizationRepository.get(id);
        this.value.id = model.id;
        this.value.kpp = model.kpp;
        this.value.full_name = model.fullName;
        this.value.inn = model.inn;
        this.value.address = model.address;
        this.value.type = model.type;
        this.value.legal_entity = model.legalEntity;
        this.value.town = {
            id: model.fkTown,
            name: model.town
        }
    }

    async delete(id) {
        let resp = await OrganizationRepository.delete(id);
        if (resp) {
            this.router.push(this.backLink);
        }
    }
    
    async load() {
        this.townList.push(...await AnimalRepository.townList());
    }

    async update() {
        let resp = await OrganizationRepository.update(
            this.value.id,
            this.value.full_name,
            this.value.inn,
            this.value.kpp,
            this.value.address,
            this.value.type,
            this.value.legal_entity,
            this.value.town.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }

    async create() {
        let resp = await OrganizationRepository.create(
            this.value.full_name,
            this.value.inn,
            this.value.kpp,
            this.value.address,
            this.value.type,
            this.value.legal_entity,
            this.value.town.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }
}