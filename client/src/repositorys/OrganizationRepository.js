import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";

export class OrganizationRepository {
    static async list() {
        const response = await fetch("/api/v1/organization/list");
        
        let list = [];
        
        let rawList = await response.json()

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new AnimalModel());
            list.push(model)
        })
        
        return list;
    }
}