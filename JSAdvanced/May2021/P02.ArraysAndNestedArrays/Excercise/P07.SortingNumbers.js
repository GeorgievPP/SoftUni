function solve(arr) {
    arr.sort((a, b) => a - b);
    const length = arr.length;
    const result = [];

    for (let i = 0; i < length; i++) {
        if (i % 2 === 1) {
            result.push(arr.pop());
        } else {
            result.push(arr.shift());
        }
    }
    return result;
}

//console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));