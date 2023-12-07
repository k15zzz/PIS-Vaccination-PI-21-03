import {RequestService} from "../services/RequestService.js";

export class PermissionRepository {
    static async scoped(userId, jwt) {
        return await RequestService.Get("/api/v1/permission/scoped?" + new URLSearchParams({
            userId: userId.toString()
        }), jwt);
    }
}