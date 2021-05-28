function solve(arr) {
  const result = [];
  let length = arr.length;

  for(let i = 0; i < length; i++){
      if(result.length === 0){
        result.push(arr[i]);
      } else {
          if(result[result.length - 1] <= arr[i]){
              result.push(arr[i]);
          }
      }
     
  }
 // console.log(result.join(', '));
  return result;
}

//solve([0,0,0,0]);

