export default function auth ({ next, jwt }){
    // console.log("auth", jwt);
    
    if(jwt === null) {
        return next({
            name: 'auth'
        });
    }
    
    return next()
}