function selectDeveloper(event, type, name) {

    console.log(type);
    console.log(name);

    $("#games").load(`Games/Filter?type=${encodeURIComponent(type)}&name=${encodeURIComponent(name)}`);


    // go to Games/Index
    //window.location = `https://localhost:44355/Games/Index?type=${type}&name=${name}`;
    //hello
}