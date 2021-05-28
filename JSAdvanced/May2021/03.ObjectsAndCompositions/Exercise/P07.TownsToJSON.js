function solve(arr) {
    const result = [];
    arr.shift();

    arr.forEach(el => {
        const [currTown, currLatitude, currLongtitude] = el.split('|').filter(el => el !== '').map(x => x.trim());
        result.push({ Town: currTown, Latitude: Number(Number(currLatitude).toFixed(2)), Longitude: Number(Number(currLongtitude).toFixed(2)) });
    })

    return JSON.stringify(result);
}

/*solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);*/