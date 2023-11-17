import {PermissionRepository} from "../repositorys/PermissionRepository.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class PermissionService {
    static can(permission) {
        const jwt = JwtResponseModel.getJwtResponse();
        if (jwt == null) return false;
        return !!jwt.scoped.find(item => item === permission);
    }

    static isAuth() {
        return !!JwtResponseModel.getJwtResponse();
    }
}