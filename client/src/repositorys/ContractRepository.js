import {SerializeService} from "../services/SerializeService.js";
import {ContractModel} from "../models/ContractModel.js";
import {RequestService} from "../services/RequestService.js";
import {AnimalModel} from "../models/AnimalModel.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class ContractRepository {
    static async list() {
        const response = await fetch("/api/v1/contract/list", {
            method: 'GET',
            headers:{
                'Authorize-token': JwtResponseModel.getJwtResponse().accessToken.toString()
            }
        });
        
        let list = [];
        
        let rawList = await response.json()

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new ContractModel());
            list.push(model)
        })
        
        return list;
    }

    static async delete(id) {
        return await RequestService.Delete('/api/v1/contract/delete', id);
    }
    
    static async get(id) {
        const row = await fetch('/api/v1/contract/read?id='+id, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorize-token': JwtResponseModel.getJwtResponse().accessToken.toString()
            }
        });
        let answer =  await row.json();
        return SerializeService.serialize(answer, new ContractModel());
    }

    static async update(id, number, startDate, endDate, fkExecutor, fkClient) {
        let model = {
            id,
            number,
            startDate,
            endDate,
            fkExecutor,
            fkClient
        };
        
        return await RequestService.Put('/api/v1/contract/update', model);
    }

    static async create(number, startDate, endDate, fkExecutor, fkClient) {
        let model = {
            number,
            startDate,
            endDate,
            fkExecutor,
            fkClient
        };
        
        console.log(JSON.stringify(model));
        
        return await RequestService.Post('/api/v1/contract/create', model);
    }
}