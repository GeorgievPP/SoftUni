function solve (x, y){
    while(y !== 0){
        let oldY = y;
        y = x % y;
        x = oldY;
    }

    console.log(x)
}

//solve(2154, 458);