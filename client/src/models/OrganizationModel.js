import {ModelHelper} from "./ModelHelper.js";

export class OrganizationModel extends ModelHelper {
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

    static _routerAction = {
        create: "organizationCreate",
        read: "organizationRead",
        update: "organizationUpdate",
        delete: "organizationDelete"
    }
}