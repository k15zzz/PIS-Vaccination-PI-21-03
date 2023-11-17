import {PermissionRepository} from "../repositorys/PermissionRepository.js";

export class JwtResponseModel {
    userId = null; 
    accessToken = null;
    login = null;
    status = false;
    time = null;
    scoped = [];
    
    static getJwtResponse() {
        let jwtStorage = localStorage.getItem("access");
        if (jwtStorage == null) return null;
        let jwtJson = JSON.parse(jwtStorage);
        let jwtModel = new JwtResponseModel();
        jwtModel.userId = jwtJson.userId;
        jwtModel.time = jwtJson.time;
        jwtModel.accessToken = jwtJson.accessToken;
        jwtModel.login = jwtJson.login;
        jwtModel.status = jwtJson.status;
        jwtModel.scoped = jwtJson.scoped;
        return jwtModel;
    }
    
    async saveLocalStorage() {
        if (this.accessToken) 
            localStorage.setItem("access", await this._buildJsonResponse());
        return this;
    }

    async _buildJsonResponse() {
        return JSON.stringify({
            userId: this.userId,
            accessToken: this.accessToken,
            login: this.login,
            status: this.status,
            scoped: await PermissionRepository.scoped(this.userId),
            time: this.time
        });
    }
}