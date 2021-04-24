function biggestOf3Numbers([num1, num2, num3]) {
    [num1, num2, num3] = [num1, num2, num3].map(Number);
    console.log(Math.max(num3, num2, num3));
}

//biggestOf3Numbers([5, -2, 7])