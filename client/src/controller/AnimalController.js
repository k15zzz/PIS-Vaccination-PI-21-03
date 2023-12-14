import {reactive} from 'vue';
import {AnimalRepository} from "../repositorys/AnimalRepository.js";
import {HelperController} from "./HelperController.js";
import {ContractRepository} from "../repositorys/ContractRepository.js";

export class AnimalController extends HelperController {
    backLink = '/animal-registry'
    value = reactive({
        id: null,
        regNum: "",
        sex: false,
        yearBirth: null,
        electronicChipNumber: "",
        name: "",
        specialMarks: null,
        category: null,
        status: {
            id: null,
            name: null
        },
        town: null
    });
    townList =  reactive([]);
    categoryList =  reactive([]);
    
    constructor(type, id = 0) {
        super(type, id);
    }
    
    async read(id) {
        const model = await AnimalRepository.get(id);
        this.value.id = model.id;
        this.value.regNum = model.regNum;
        this.value.sex = model.sex;
        this.value.yearBirth = model.yearBirth;
        this.value.electronicChipNumber = model.electronicChipNumber;
        this.value.name = model.name;
        this.value.specialMarks = model.specialMarks;
        this.value.town = {
            id: model.fkTown,
            name: model.town,
        };
        this.value.category = {
            id: model.fkAnimalCategory,
            name: model.animalCategory,
        };
        this.value.status = {
            id: model.fkAnimalStatus,
            name: model.animalStatus,
        };
    }
    
    async load() {
        this.townList.push(...await AnimalRepository.townList());
        this.categoryList.push(...await AnimalRepository.categoryList());
    }

    async delete(id) {
        let resp = await AnimalRepository.delete(id);
        if (resp) {
            this.router.push(this.backLink);
        }
    }

    async update() {
        let resp =  await AnimalRepository.update(
            this.value.id,
            this.value.regNum,
            this.value.sex,
            this.value.yearBirth,
            this.value.electronicChipNumber,
            this.value.name,
            this.value.specialMarks,
            this.value.category.id,
            this.value.town.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }
    
    async create() {
        let resp = await AnimalRepository.create(
            this.value.regNum,
            this.value.sex,
            this.value.yearBirth,
            this.value.electronicChipNumber,
            this.value.name,
            this.value.specialMarks,
            this.value.category.id,
            this.value.town.id,
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }
}