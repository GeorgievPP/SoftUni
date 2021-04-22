function binaryLogarithm(arr) {
    arr = arr.map(Number);

    for(let number in arr) {
        console.log(Math.log2(number))
    }
}

