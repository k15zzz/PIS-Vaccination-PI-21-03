import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";
import {RequestService} from "../services/RequestService.js";
import {OrganizationModel} from "../models/OrganizationModel.js";

export class OrganizationRepository {
    static async list() {
        const rawList = await RequestService.Get("/api/v1/organization/list");
        let list = [];
        
        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new AnimalModel());
            list.push(model)
        })
        
        return list;
    }

    static async delete(id) {
        return await RequestService.Delete('/api/v1/organization/delete', id);
    }

    static async get(id) {
        const row = await RequestService.Get('/api/v1/organization/read?id='+id);
        return SerializeService.serialize(row, new OrganizationModel());
    }

    static async update(
        id,
        fullName,
        inn,
        kpp,
        address,
        type,
        legal_entity,
        fkTown
    ) {
        const model = {
            id,
            fullName,
            inn,
            kpp,
            address,
            type,
            legal_entity,
            fkTown
        }
        
        return RequestService.Put('/api/v1/organization/update', model)
    }
    
    static async create(
        fullName,
        inn,
        kpp,
        address,
        type,
        legal_entity,
        fkTown
    ) {
        const model = {
            fullName,
            inn,
            kpp,
            address,
            type,
            legal_entity,
            fkTown
        }
        
        console.log(JSON.stringify(model));
        
        return RequestService.Post('/api/v1/organization/create', model)
    }
}