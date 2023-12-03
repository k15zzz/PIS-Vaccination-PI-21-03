import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";
import {RequestService} from "../services/RequestService.js";
import {VaccinationModel} from "../models/VaccinationModel.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class VaccinationRepository {
    static async list() {
        const response = await fetch("/api/v1/vaccination/list", {
            method: 'GET',
            headers:{
                'Authorize-token': JwtResponseModel.getJwtResponse().accessToken.toString()
            }
        });
        
        let list = [];
        
        let rawList = await response.json()

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
        const row = await fetch('/api/v1/vaccination/read?id='+id, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorize-token': JwtResponseModel.getJwtResponse().accessToken.toString()
            }
        });
        let answer =  await row.json();;
        return SerializeService.serialize(answer, new VaccinationModel());
    }
}