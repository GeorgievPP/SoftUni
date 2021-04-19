function triangleArea(arr) {
    arr = arr.map(Number);
    let sideA = arr[0], sideB = arr[1], sideC = arr[2];
    let halfPerimeter = (sideA + sideB + sideC) / 2;
    let area = Math.sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
    console.log(area); 
}

triangleArea([2, 3.5, 4])