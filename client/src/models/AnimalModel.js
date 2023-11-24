import {ModelHelper} from "./ModelHelper.js";

export class AnimalModel extends ModelHelper {
    id = null;
    regNum = null;
    animalCategory = null;
    fkAnimalCategory = null;
    sex = null;
    yearBirth = null;
    electronicChipNumber = null;
    name = null;
    photos = null;
    specialMarks = null;
    town = null;
    
    static _titleParams = {
        id: "ID",
        regNum: "Регистрационный номер",
        category: "Категория",
        sex: "Пол",
        yearBirth: "Дата рождения",
        electronicChipNumber: "Номер электронного чипа",
        name: "Кличка",
        specialMarks: "Особые приметы",
        town: "Город"
    }
    
    static _permissions = {
        create: "create-animal",
        read: "read-animal",
        update: "update-animal",
        delete: "delete-animal"
    }
    
    static _routerAction = {
        create: "animalCreate",
        read: "animalRead",
        update: "animalUpdate",
        delete: "animalDelete"
    }
}