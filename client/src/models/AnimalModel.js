export class AnimalModel {
    id = null;
    regNum = null;
    category = null;
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