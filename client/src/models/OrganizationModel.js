export class OrganizationModel {
    id = null;
    fullName = null;
    inn = null;
    kpp = null;
    address = null;
    type = null;
    legalEntity = null;
    fkTown = null;
    town = null;
    
    static _titleParams = {
        id: "ID",
        fullName: "Наименование",
        inn: "ИНН",
        kpp: "КПП",
        address: "Адрес",
        type: "Тип организации",
        legalEntity: "ИП",
        town: "Город",
    }
    
    static _permissions = {
        create: "create-organization",
        read: "read-organization",
        update: "update-organization",
        delete: "delete-organization"
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