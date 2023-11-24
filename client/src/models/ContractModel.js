import {ModelHelper} from "./ModelHelper.js";

export class ContractModel extends ModelHelper {
    id = null;
    number = null;
    startDate = null;
    endDate = null;
    fkExecutor = null;
    fkClient = null;
    executor = null;
    client = null;
    
    static _titleParams = {
        id: "ID",
        number: "Номер",
        startDate: "Дата заключение",
        endDate: "Дата действия",
        executor: "Исполнитель",
        client: "Заказчик",
    }
    
    static _permissions = {
        create: "create-contract",
        read: "read-contract",
        update: "update-contract",
        delete: "delete-contract"
    }

    static _routerAction = {
        create: "contractCreate",
        read: "contractRead",
        update: "contractUpdate",
        delete: "contractDelete"
    }
}