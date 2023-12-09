import {PermissionRepository} from "../repositorys/PermissionRepository.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

export class PermissionService {
    static can(permission) {
        const jwt = JwtResponseModel.getJwtResponse();
        if (jwt == null) return false;
        return !!jwt.scoped.find(item => item === permission);

    }

    static async isAuth() {
        const jwt = JwtResponseModel.getJwtResponse();
        let status = !!jwt;
        
        if (status) {
            let scoped = await PermissionRepository.scoped(jwt.userId);
            if (scoped.status === 401) {
                localStorage.clear();
                status = false;
            }
        }
        
        return status;
    }
}