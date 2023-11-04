import {ScopedModel} from "../models/ScopedModel";

export class PermissionRepository {
    static async scoped(userId) {
        const response = await fetch("/api/v1/permission/scoped?" + new URLSearchParams({
            userId: userId.toString()
        }));
        const objects = await response.json();
        let scoped = new ScopedModel();
        scoped.list = JSON.parse(objects);
        return scoped;
    }
}