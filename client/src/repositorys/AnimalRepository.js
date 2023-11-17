import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";

export class AnimalRepository {
    static async list() {
        const response = await fetch("/api/v1/animal/list?");
        
        let list = [];
        
        let rawList = await response.json()

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new AnimalModel());
            list.push(model)
        })
        
        return list;
    }
}