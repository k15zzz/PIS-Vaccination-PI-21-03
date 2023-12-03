import {ModelHelper} from "./ModelHelper.js";

export class LogModel extends ModelHelper {
    id = null;
    date_time = null;
    object_instance_id = null;
    object_description_after_action = null;
    fk_user = null;
    name = null;
    surname = null;
    patronymic = null;
    phone = null;
    email = null;
    workPhone = null;
    workEmail = null;
    login = null;
    OrgName = null;
    RoleName = null;

    static _titleParams = {
        id: "ID",
        surname: "Фамилия",
        name: "Имя",
        patronymic: "Отчество",
        phone: "Телефон",
        email: "Электронная почта",
        OrgName:"Организация",
        RoleName:"Должность",
        workPhone: "Рабочий телефон",
        workEmail: "Рабочая электронная почта",
        login:"Логин",
        date_time: "Дата и время",
        object_instance_id: "Идентификационный номер экземпляра объекта",
        object_description_after_action: "Описание экземпляра объекта после совершения действия",
        
    }

    static _permissions = {
        read: "read-log",
        
    }

    static _routerAction = {
        read: "logRead",
       
    }
}