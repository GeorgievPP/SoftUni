function cappyJuice(input) {
    let saveJuices = new Map;
    let lessThan1000 = new Map;
    let result = new Map;
 
 
    for(let juice of input) {
        let splitString = juice.split(/\s*[=>]\s*/g);
        let juiceName = splitString[0];
        let quantity = Number(splitString[2]);
 
        if(saveJuices.has(juiceName)) {
            let getValue = saveJuices.get(juiceName);
            saveJuices.delete(juiceName);
            saveJuices.set(juiceName, quantity + getValue);
 
        }
        else {
            saveJuices.set(juiceName, quantity);
        }
 
    }
 
    for(let [k, v] of saveJuices) {
        let divideBottles = Math.floor(v / 1000);
        if(divideBottles >= 1) {
            console.log(`${k} => ${divideBottles}`);
        }
 
    }
 
}



console.log(juiceStore(
    ['Orange => 2000',
        'Peach => 1432',
        'Banana => 450',
        'Peach => 600',
        'Strawberry => 549']
));