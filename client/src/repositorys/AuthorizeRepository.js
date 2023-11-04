import {JwtResponseModel} from "./../models/JwtResponseModel";
import {deserialize} from 'class-transformer';

export class AuthorizeRepository {
    static async auth(login, password) {
        const response = await fetch("/api/v1/authorize/auth", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                login,
                password
            })
        });
        
        const object = await response.json();
        
        const jwtModel = new JwtResponseModel();
        
        jwtModel.userId = object.userId;
        jwtModel.time = object.time;
        jwtModel.accessToken = object.accessToken;
        jwtModel.login = object.login;
        jwtModel.status = object.status;
        
        return jwtModel;
    }
}