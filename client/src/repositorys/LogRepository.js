import {SerializeService} from "../services/SerializeService.js";
import {LogModel} from "../models/LogModel.js";
import {RequestService} from "../services/RequestService.js";
import JsonExcel from "vue-json-excel3";

export class LogRepository {
    static async list() {
        const response = await fetch("/api/v1/logreader/list");

        let list = [];

        let rawList = await response.json()

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new LogModel());
            list.push(model)
        })

        return list;
    }

    static async delete(id) {
        return await RequestService.Delete('/api/v1/logreader/delete', id);
    }
    
    static async get(id) {
        const row = await RequestService.Get('/api/v1/logreader/read?id='+id);
        return SerializeService.serialize(row, new LogModel());
    }
    static async export(id)
    {
        const row = await RequestService.Get('/api/v1/logreader/read?id='+id);
        let rawList = await row.json()
        JsonExcel.data(rawList);
    }
    //todo: экспорт
}