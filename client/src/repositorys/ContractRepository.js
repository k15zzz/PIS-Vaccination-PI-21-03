import {SerializeService} from "../services/SerializeService.js";
import {ContractModel} from "../models/ContractModel.js";

export class ContractRepository {
    static async list() {
        const response = await fetch("/api/v1/contract/list");
        
        let list = [];
        
        let rawList = await response.json()

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new ContractModel());
            list.push(model)
        })
        
        return list;
    }
}