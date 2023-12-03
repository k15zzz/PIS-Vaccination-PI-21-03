import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";
import {RequestService} from "../services/RequestService.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class AnimalRepository {
    static async list() {
        const response = await fetch("/api/v1/animal/list", {
            method: 'GET',
            headers:{
                'Authorize-token': JwtResponseModel.getJwtResponse().accessToken.toString()
            }
        });
        
        let list = [];
        
        let rawList = await response.json()

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new AnimalModel());
            list.push(model)
        })
        
        return list;
    }
    
    static async delete(id) {
        return await RequestService.Delete('/api/v1/animal/delete', id);
    }

    static async update(
        id,
        regNum,
        sex,
        yearBirth,
        electronicChipNumber,
        name,
        specialMarks,
        fkAnimalCategory,
        fkTown)
    {
        let model = {
            id,
            regNum,
            sex,
            yearBirth,
            electronicChipNumber,
            name,
            specialMarks,
            fkAnimalCategory,
            fkTown
        };

        return await RequestService.Put('/api/v1/animal/update', model);
    }

    static async create( 
        regNum, 
        sex, 
        yearBirth,
        electronicChipNumber,
        name,
        specialMarks,
        fkAnimalCategory,
        fkTown) 
    {
        let model = {
            regNum,
            sex,
            yearBirth,
            electronicChipNumber,
            name,
            specialMarks,
            fkAnimalCategory,
            fkTown
        };
        
        return await RequestService.Post('/api/v1/animal/create', model);
    }
    
    static async get(id) {
        const row = await fetch('/api/v1/animal/read?id=' + id, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorize-token': JwtResponseModel.getJwtResponse().accessToken.toString()
            }
        });
        let answer =  await row.json();
        return SerializeService.serialize(answer, new AnimalModel());
    }
    
    static async categoryList() 
    {
        return await RequestService.Get('/api/v1/animalCategory/list');
    }

    static async townList()
    {
        return await RequestService.Get('/api/v1/town/list');
    }
}