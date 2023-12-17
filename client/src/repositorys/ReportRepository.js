import {RequestService} from "../services/RequestService.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";
import {SerializeService} from "../services/SerializeService.js";
import {AnimalModel} from "../models/AnimalModel.js";
import {ReportModel} from "../models/ReportModel.js";

export class ReportRepository {
    static async make(
        dateStar,
        dateFinish,
        towns
    ) {
        let model = {
            dateStar,
            dateFinish,
            towns
        };

        return await RequestService.Post('/api/v1/statistic/make', model);
    }

    static async list() {
        const rawList = await RequestService.Get("/api/v1/statistic/list");
        let list = [];

        rawList.forEach((row) => {
            let model = SerializeService.serialize(row, new ReportModel());
            list.push(model)
        })

        return list;
    }

    static async delete(id) {
        return await RequestService.Delete('/api/v1/statistic/delete', id);
    }

    static async update(
        id,
        DateStart,
        DateFinish,
        UpdateStatus,
        FkStatus,
        statisticTown
        ) {
        let model = {
            id,
            DateStart,
            DateFinish,
            UpdateStatus,
            FkStatus,
            statisticTown
        };
        
        return await RequestService.Put('/api/v1/statistic/update', model);
    }

    static async create(
        DateStart,
        DateFinish,
        UpdateStatus,
        FkStatus,
        statisticTown
        ) {
        let model = {
            DateStart,
            DateFinish,
            UpdateStatus,
            FkStatus,
            statisticTown
        };

        return await RequestService.Post('/api/v1/statistic/create', model);
    }

    static async get(id) {
        const row = await RequestService.Get('/api/v1/statistic/read?id='+id);
        return SerializeService.serialize(row, new ReportModel());
    }

    static async statusList()
    {
        return await RequestService.Get('/api/v1/statistic/status-list');
    }
}