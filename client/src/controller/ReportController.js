import {reactive, ref} from 'vue';
import {AuthorizeRepository} from "./../repositorys/AuthorizeRepository";
import {JwtResponseModel} from "./../models/JwtResponseModel";
import { useRouter, useRoute } from 'vue-router'
import {AnimalRepository} from "../repositorys/AnimalRepository.js";
import {ContractRepository} from "../repositorys/ContractRepository.js";
import {OrganizationRepository} from "../repositorys/OrganizationRepository.js";
import {HelperController} from "./HelperController.js";
import {ReportRepository} from "../repositorys/ReportRepository.js";

export class ReportController extends HelperController {
    backLink = '/report-registry';
    report = reactive([]);
    value = reactive({
        towns: [],
        dateStart: null,
        dateFinis: null,
        updateStatus: null,
        status: null
    });
    townList =  reactive([]);
    statusList =  reactive([]);

    constructor(type, id = 0) {
        super(type, id);
    }
    
    async make() {
        this.report.splice(0 , this.report.length);
        this.report.push(...await ReportRepository.make(
            this.value.dateStart, 
            this.value.dateFinis,
            this.value.towns.map(t => t.id)
        ));
    }

    async read(id) {
        const model = await ReportRepository.get(id);
        this.value.id = model.id;
        this.value.dateStart = model.dateStart;
        this.value.dateFinis = model.dateFinish;
        this.value.updateStatus = model.updateStatus;
        this.value.status = {
            id: model.fkStatus,
            name: model.status,
        };
        model.statisticTown.forEach(item => {
            this.value.towns.push({
                id: item.fkTown,
                name: item.town,
                townsService: null
            });
            this.report.push( {
                name: item.town,
                count: item.count,
                cost: item.cost,
            });
        });
    }
    
    async load() {
        this.statusList.push(...await ReportRepository.statusList());
        this.townList.push(...await AnimalRepository.townList());
    }

    async update() {
        await this.make();
        
        let statisticTown = [];

        this.report.forEach((item) => {
            statisticTown.push({
                count: item.count,
                cost: item.cost,
                fkTown: item.fkTown,
                fkStatistic: 0
            });
        });
        
        let resp =  await ReportRepository.update(
            this.value.id,
            this.value.dateStart,
            this.value.dateFinis,
            this.value.updateStatus,
            this.value.status.id,
            statisticTown
        );
        
        if (resp) {
            this.router.push(this.backLink);
        }
    }

    async delete(id) {
        let resp = await ReportRepository.delete(id);
        if (resp) {
            this.router.push(this.backLink);
        }
    }

    async create() {
        await this.make();

        let statisticTown = [];

        this.report.forEach((item) => {
            statisticTown.push({
                count: item.count,
                cost: item.cost,
                fkTown: item.fkTown,
                fkStatistic: 0
            });
        });
        
        let resp =  await ReportRepository.create(
            this.value.dateStart,
            this.value.dateFinis,
            this.value.updateStatus,
            this.value.status.id,
            statisticTown
        );
        if (resp) {
            this.router.push(this.backLink);
        }
    }
}