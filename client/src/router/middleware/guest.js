export default function guest ({ next, jwt, isAuth}){
    console.log('guest', jwt);
    
    if(isAuth){
        return next({
            name: 'index'
        })
    }

    return next();
}