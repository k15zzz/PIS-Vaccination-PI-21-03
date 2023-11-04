import {JwtResponseModel} from "./../models/JwtResponseModel";

export class PermissionController {
    static isAuthenticated() {
        return JwtResponseModel.getJwtResponse() != null;
    }
}