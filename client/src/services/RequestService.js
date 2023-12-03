import {informerStores} from "../stores/informerStores.js";
import {JwtResponseModel} from "../models/JwtResponseModel.js";

// const iStores = informerStores();

export class RequestService {
    static async Delete (url, id)
    {
        let response = null;
        
        try {
            response = await fetch(url + '?id=' + id, {
                method: 'DELETE',
                headers: this._buildHeaders(),
                body: JSON.stringify(id)
            });

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            // iStores.set(e, "error");
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
                headers: this._buildHeaders(),
                body: JSON.stringify(data)
            });

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            // iStores.set(e, "error");
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
                headers: this._buildHeaders(),
                body: JSON.stringify(data)
            });

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            // iStores.set(e, "error");
            response = e.response;
            console.error(response)
        }
        
        return response;
    }
    
    static async Get(url, jwt = null) 
    {
        let response = null;

        try {
            response = await fetch(url, {
                method: 'GET',
                headers: this._buildHeaders(jwt)
            });

            if (!response.ok) { // если HTTP-статус вне диапазона 200-299
                let error = new Error(response.statusText);
                error.response = response;
                throw error;
            }
            
            response = await response.json();
        } catch (e) {
            // iStores.set(e, "error");
            response = e.response;
            console.error(response)
        }

        return response;
    }
    
    static _buildHeaders(jwt)
    {
        if (jwt == null) {
            let jwtModel = JwtResponseModel.getJwtResponse();
            if (jwtModel == null) {
                return {
                    'Content-Type': 'application/json;charset=utf-8'
                }
            }
            return {
                'Authorization': jwtModel.accessToken,
                'Content-Type': 'application/json;charset=utf-8'
            }
        } else {
            return {
                'Authorization': jwt,
                'Content-Type': 'application/json;charset=utf-8'
            }
        }
    }
}