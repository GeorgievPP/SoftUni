function solve(arr) {
    const obj = {};
    let result;

    arr.forEach(el => {
        const [productName, productPrice] = el.split(' : ');
        if (!obj.hasOwnProperty(productName[0])) {
            obj[productName[0]] = [];
        }
        obj[productName[0]].push({ productName, productPrice: Number(productPrice) });

        result = Object.entries(obj).sort((a, b) => a[0].localeCompare(b[0]));

        obj[productName[0]].sort((a, b) => a.productName.localeCompare(b.productName));

    })
    for (let [letter, arr] of result) {
        console.log(letter);
        for (let el of arr) {
            console.log(`  ${el.productName}: ${el.productPrice}`);
        }

    }
}

/*solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);*/