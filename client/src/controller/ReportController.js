import {reactive, ref} from 'vue';
import {AuthorizeRepository} from "./../repositorys/AuthorizeRepository";
import {JwtResponseModel} from "./../models/JwtResponseModel";
import { useRouter, useRoute } from 'vue-router'
import {AnimalRepository} from "../repositorys/AnimalRepository.js";
import {ContractRepository} from "../repositorys/ContractRepository.js";
import {OrganizationRepository} from "../repositorys/OrganizationRepository.js";
import {HelperController} from "./HelperController.js";
import {ReportRepository} from "../repositorys/ReportRepository.js";

export class ReportController {
    backLink = '/';
    report = reactive([]);
    value = reactive({
        towns: [],
        dateStart: null,
        dateFinis: null,
    });
    townList =  reactive([]);
    
    async make() {
        this.report.splice(0 , this.report.length);
        this.report.push(...await ReportRepository.make(
            this.value.dateStart, 
            this.value.dateFinis,
            this.value.towns.map(t => t.id)
        ));
        console.log(this.report);
    }
    
    async load() {
        this.townList.push(...await AnimalRepository.townList());
        console.log(this.townList);
    }
}