import {ModelHelper} from "./ModelHelper.js";

export class ReportModel extends ModelHelper {
    dateStart = null;
    dateFinish = null;
    updateStatus = null;
    fkStatus = null;
    status = null;
    statisticTown = null;

    static _titleParams = {
        id: "ID",
        dateStart: "Дата начала",
        dateFinish: "Дата конца",
        status: "Статус",
        updateStatus: "Дата обновления статуса",
    }

    static _permissions = {
        create: "create-statistic",
        read: "create-statistic",
        update: "create-statistic",
        delete: "create-statistic"
    }

    static _routerAction = {
        create: "reportCreate",
        read: "reportRead",
        update: "reportUpdate",
        delete: "reportDelete"
    }
}