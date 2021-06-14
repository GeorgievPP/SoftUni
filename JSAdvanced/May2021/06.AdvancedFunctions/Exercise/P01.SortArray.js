function solve(arr, type) {
    const map = {
        'asc': (a, b) => a - b,
        'desc': (a, b) => b - a
    }

    return arr.sort(map[type])
}

console.log(solve([6, 7, 8, 14, 17], 'asc'));