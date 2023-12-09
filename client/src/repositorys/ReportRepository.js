import {RequestService} from "../services/RequestService.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class ReportRepository {
    static async make(
        dateStar,
        dateFinish,
        towns
    )
    {
        let model = {
            dateStar,
            dateFinish,
            towns
        };
        
        console.log(JSON.stringify(model));

        return await RequestService.Post('/api/v1/statistic/make', model);
    }
}