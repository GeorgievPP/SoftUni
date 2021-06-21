function solve() {
  const inputText = document.getElementById('text').value.split(' ');
  const currentCase = document.getElementById('naming-convention').value;
  const result = document.getElementById('result');
  result.textContent = convert(inputText, currentCase);

  function convert(inputText, currentCase) {
    switch(currentCase) {
      case 'Camel Case':
        return inputText
         .map((el) => el.toLowerCase())
         .reduce((a, c, i) => {
           i === 0 ? c : (c = c[0].toUpperCase() + c.slice(1));
           return a + c;
        }, '');
        case 'Pascal Case':
          return inputText
           .map((el) => el.toLowerCase())
           .reduce((a, c) => {
             return a + (c[0].toUpperCase() + c.slice(1));
          }, '');
        default:
          return 'Error!';

    }
  }
}