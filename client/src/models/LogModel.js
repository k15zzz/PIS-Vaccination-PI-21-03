import {ModelHelper} from "./ModelHelper.js";

export class LogModel extends ModelHelper {
    id = null;
    logDate = null;
    objId = null;
    objDescr = null;
    fk_user = null;
    name = null;
    surname = null;
    patronymic = null;
    phone = null;
    email = null;
    workPhone = null;
    workEmail = null;
    login = null;
    organization = null;
    position = null;

    static _titleParams = {
        id: "ID",
        surname: "Фамилия",
        name: "Имя",
        patronymic: "Отчество",
        phone: "Телефон",
        email: "Электронная почта",
        organization:"Организация",
        position:"Должность",
        workPhone: "Рабочий телефон",
        workEmail: "Рабочая электронная почта",
        login:"Логин",
        logDate: "Дата и время",
        objId: "Номер экземпляра объекта",
        objDescr: "Описание действия",
        
    }

    static _permissions = {
        read: "read-log",
        
    }

    static _routerAction = {
        read: "logRead",
        export: "logExport",
        delete: "logDelete"
       
    }
}