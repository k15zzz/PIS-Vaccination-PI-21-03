import {PermissionRepository} from "../repositorys/PermissionRepository.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class PermissionService {
    static can(permission) {
        const jwt = JwtResponseModel.getJwtResponse();
        if (jwt == null) return false;
        const scoped = PermissionRepository.scoped(jwt.userId);
        return !!scoped.list.find(item => item === permission);
    }

    static isAuth() {
        return !!JwtResponseModel.getJwtResponse();
    }
}