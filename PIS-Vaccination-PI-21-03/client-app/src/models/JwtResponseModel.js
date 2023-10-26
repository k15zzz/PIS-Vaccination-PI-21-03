export class JwtResponseModel {
    userId = null; 
    accessToken = null;
    login = null;
    status = false;
    time = null;
    
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
        return jwtModel;
    }
    
    saveLocalStorage() {
        if (this.accessToken) 
            localStorage.setItem("access", this._buildJsonResponse());
        return this;
    }
    
    _buildJsonResponse() {
        return JSON.stringify({
            accessToken: this.accessToken,
            login: this.login,
            status: this.status,
            time: this.time
        });
    }
}