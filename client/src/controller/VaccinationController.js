import {reactive} from 'vue';
import {AnimalRepository} from "../repositorys/AnimalRepository.js";
import {HelperController} from "./HelperController.js";
import {ContractRepository} from "../repositorys/ContractRepository.js";
import {OrganizationRepository} from "../repositorys/OrganizationRepository.js";
import {VaccinationRepository} from "../repositorys/VaccinationRepository.js";

export class VaccinationController extends HelperController {
    backLink = '/vaccination-registry'
    value = reactive({
        id: null,
        type: null,
        date: null,
        numOfSeries: null,
        dateOfExpire: null,
        positionOfDoc: null,
        org: null,
        contract: null,
        animal: null
    });
    organizationList =  reactive([]);
    contractList =  reactive([]);
    animalList =  reactive([]);
    
    constructor(type, id = 0) {
        super(type, id);
    }
    
    async read(id) {
        const model = await VaccinationRepository.get(id);
        this.value.id = model.id;
        this.value.type = model.type;
        this.value.date = model.date;
        this.value.numOfSeries = model.numOfSeries;
        this.value.dateOfExpire = model.dateOfExpire;
        this.value.positionOfDoc = model.positionOfDoc;
        this.value.org = {
            id: model.fkOrg,
            fullName: model.org,
        };
        this.value.contract = {
            id: model.fkContract,
            number: model.contract,
        };
        this.value.animal = {
            id: model.fkAnimal,
            name: model.animal,
        };
    }
    
    async load() {
        this.organizationList.push(...await OrganizationRepository.list());
        this.contractList.push(...await ContractRepository.list());
        this.animalList.push(...await AnimalRepository.list());
    }

    async delete(id) {
        let resp = await VaccinationRepository.delete(id);
        if (resp) {
            this.router.push(this.backLink);
        }
    }

    async update() {
        let resp =  await VaccinationRepository.update(
            this.value.id,
            this.value.type,
            this.value.date,
            this.value.numOfSeries,
            this.value.dateOfExpire,
            this.value.positionOfDoc,
            this.value.org.id,
            this.value.contract.id,
            this.value.animal.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }
    
    async create() {
        let resp = await VaccinationRepository.create(
            this.value.type,
            this.value.date,
            this.value.numOfSeries,
            this.value.dateOfExpire,
            this.value.positionOfDoc,
            this.value.org.id,
            this.value.contract.id,
            this.value.animal.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }
}