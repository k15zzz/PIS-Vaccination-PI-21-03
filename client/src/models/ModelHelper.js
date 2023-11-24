export class ModelHelper {
    static _titleParams = []
    static _permissions = []
    static _routerAction = []
    
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
    
    static getRouterAction(action) {
            return this._routerAction[action];
    }
}