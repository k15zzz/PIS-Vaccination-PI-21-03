
export default function log ({ next }){
    //TODO: Декодировать jwt и достать оттуда пользователя
    //TODO: при ловле запросов создавать еще запрос на логирование этого запроса
    //TODO: На беке записывать этот запрос в бд

    let jwtStorage = localStorage.getItem("access");
    let jwtJson = JSON.parse(jwtStorage);
    let user =  jwtJson.userId;
    console.log("logged: ", user);

    return next();
}