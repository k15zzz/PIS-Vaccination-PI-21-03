import {ModelHelper} from "./ModelHelper.js";

export class VaccinationModel extends ModelHelper {
    id = null;
    type = null;
    date = null;
    numOfSeries = null;
    dateOfExpire = null;
    positionOfDoc = null;
    fkOrg = null;
    fkContract = null;
    fkAnimal = null;
    org = null;
    contract = null;
    animal = null;
    
    static _titleParams = {
        id: "ID",
        type: "Тип",
        date: "Дата заключения",
        numOfSeries: "Номер",
        dateOfExpire: "Дата чего-то",
        positionOfDoc: "Должность",
        org: "Организация",
        contract: "Контракт",
        animal: "Животное"
    }
    
    // todo: добавить права в базу данных
    static _permissions = {
        // create: "create-vaccination",
        // read: "read-vaccination",
        // update: "update-vaccination",
        // delete: "delete-vaccination"
        create: "create-animal",
        read: "read-animal",
        update: "update-animal",
        delete: "delete-animal"
    }
    
    static _routerAction = {
        create: "vaccinationCreate",
        read: "vaccinationRead",
        update: "vaccinationUpdate",
        delete: "vaccinationDelete"
    }
}