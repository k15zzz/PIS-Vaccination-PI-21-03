export default function auth ({ next, jwt, isAuth}){
    // console.log("auth", jwt);
    
    if(!isAuth) {
        return next({
            name: 'auth'
        });
    }
    
    return next()
}