import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";
import {RequestService} from "../services/RequestService.js";
import {VaccinationModel} from "../models/VaccinationModel.js";

export class VaccinationRepository {
    static async list() {
        const rawList = await RequestService.Get("/api/v1/vaccination/list");
        let list = [];
        
        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new VaccinationModel());
            list.push(model)
        })
        
        return list;
    }
    
    static async delete(id) {
        return await RequestService.Delete('/api/v1/vaccination/delete', id);
    }

    static async update(
        id,
        type,
        date,
        numOfSeries,
        dateOfExpire,
        positionOfDoc,
        fkOrg,
        fkContract,
        fkAnimal
    )
    {
        let model = {
            id,
            type,
            date,
            numOfSeries,
            dateOfExpire,
            positionOfDoc,
            fkOrg,
            fkContract,
            fkAnimal
        };

        return await RequestService.Put('/api/v1/vaccination/update', model);
    }

    static async create(
        type,
        date,
        numOfSeries,
        dateOfExpire,
        positionOfDoc,
        fkOrg,
        fkContract,
        fkAnimal
    ) 
    {
        let model = {
            type,
            date,
            numOfSeries,
            dateOfExpire,
            positionOfDoc,
            fkOrg,
            fkContract,
            fkAnimal
        };
        
        return await RequestService.Post('/api/v1/vaccination/create', model);
    }
    
    static async get(id) {
        const row = await RequestService.Get('/api/v1/vaccination/read?id='+id);
        return SerializeService.serialize(row, new VaccinationModel());
    }
}