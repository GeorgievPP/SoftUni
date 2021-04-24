function triangleOfDollars([number]) {
    number = Number(number);

    for(let i = 1; i <= number; i++) {
       console.log('$'.repeat(i));
    }
}

//triangleOfDollars('3');