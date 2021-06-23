function solve(arr) {
    let obj = {};
    arr.forEach(el => {
        let [town, product, price] = el.split(' | ');
        price = Number(price);

        if (!obj.hasOwnProperty(product)) {
            obj[product] = { price, town };
        } else {
            if (obj[product].price > price) {
                obj[product] = { price, town };
            }
        }
    })

    for (let el in obj) {
        console.log(`${el} -> ${obj[el].price} (${obj[el].town})`)
    }
}




/*function solve(arr) {
    let obj = {};
    
    for(const data of arr) {
        let [town, product, stringPrice] = data.split(' | ');
        let price =Number(stringPrice);

        if(obj[product]) {
            obj[product] = obj[product].price <= price ? obj[product] : { town, price: price };
        } else {
            obj[product] = { town, price: price };
        }
    };

    for(const product in obj) {
        console.log(`${product} -> ${obj[product].price} (${obj[product].town})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);*/