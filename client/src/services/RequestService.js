import {informerStores} from "../stores/informerStores.js";

const iStores = informerStores();

export class RequestService {
    static async Delete (url, id)
    {
        let response = null;
        
        try {
            response = await fetch(url + '?id=' + id, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(id)
            });

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            iStores.set(e, "error");
            response = e.response;
            console.error(response)
        }

        return response;
    }
    
    static async Put (url, data)
    {
        let response = null;

        try {
            response = await fetch(url, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(data)
            });

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            iStores.set(e, "error");
            response = e.response;
            console.error(response)
        }

        return response;
    }
    
    static async Post (url, data) 
    {
        let response = null;
        
        try {
            response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(data)
            });

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            iStores.set(e, "error");
            response = e.response;
            console.error(response)
        }
        
        return response;
    }
    
    static async Get(url) 
    {
        let response = null;

        try {
            response = await fetch(url);

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            iStores.set(e, "error");
            response = e.response;
            console.error(response)
        }

        return response;
    }
}