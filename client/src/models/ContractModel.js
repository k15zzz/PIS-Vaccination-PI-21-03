export class ContractModel {
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
    
    getValue(params) {
        return this[params];
    }
    
    static getTitle(params) {
        return this._titleParams[params];
    }

    static getParams() {
        return Object.keys(this._titleParams);
    }

    static getPermission(type) {
        return this._permissions[type];
    }
}