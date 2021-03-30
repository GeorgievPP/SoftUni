function countLetterOcurrencesInAString([strng, letter]){
    let count = 0;

    for(let char of strng){
        if(char == letter){
            count++;
        }
    }

    console.log(count);
}
countLetterOcurrencesInAString(['hello', 'l'])