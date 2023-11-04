import {JwtResponseModel} from "~/models/JwtResponseModel";

export class UserModel {
    
    id = null;
    login = null;
    jwtResponseModel = null;
    
    getJwtResponse() {
        return JwtResponseModel.getJwtResponse()
    }
}