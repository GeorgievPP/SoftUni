function solve(arr) {
    const result = [];
    let num = 1;

    for (let el of arr) {
        if (el === 'add') {
            result.push(num);
        }
        if (el === 'remove') {
            result.pop();
        }

        num++;
    }

    console.log(result.length == 0 ? 'Empty' : result.join('\n'))
}

/*solve(['add', 
'add', 
'remove', 
'add', 
'add']
);*/