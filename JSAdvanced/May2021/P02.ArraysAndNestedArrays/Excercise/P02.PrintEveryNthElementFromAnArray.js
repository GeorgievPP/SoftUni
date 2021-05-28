function solve(arr, n) {
    const result = [];

    for (let i = 0; i <= arr.length; i += n) {
        result.push(arr[i]);
    }

    return result.filter((e) => e != undefined);
}

//solve(['5', '20', '31', '4', '20'], 2);