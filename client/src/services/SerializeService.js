export class SerializeService {
    static serialize(objects, entityClass) {
        for (const [key, value] of Object.entries(objects)) {
            entityClass[key] = value
        }
        return entityClass;
    }
}