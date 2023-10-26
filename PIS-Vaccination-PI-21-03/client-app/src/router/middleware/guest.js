export default function guest ({ next, jwt }){
    console.log('guest', jwt);
    
    if(jwt !== null){
        return next({
            name: 'index'
        })
    }

    return next();
}