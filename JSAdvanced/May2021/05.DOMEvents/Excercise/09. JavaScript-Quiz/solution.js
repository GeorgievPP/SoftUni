function solve() {
  const ul = document.querySelector('section');
  const h2Questions = [...document.querySelectorAll('h2')].slice(1);
  const pAnswers = [...document.querySelectorAll('p')].slice(2);
  const result = document.getElementById('result');

  let answers = [];

  ul.addEventListener('click', function(ev) {
    const pText = ev.target.textContent;
    const p1 = ev.target.parentNode.parentNode.parentNode.children[1].querySelector('p');
    const p2 = ev.target.parentNode.parentNode.parentNode.children[2].querySelector('p');

    if(ev.target.tagName === 'P') {
      if(pText === 'onclick' || pText === 'JSON.stringify()' || 
        pText === 'A programming API for XML documents') {
          answers.push(pText);
        }

        if(h2Questions.length === 0) {
          ul.style.display = 'none';
          result.style.display = 'block';
          if(answers.length === 3) {
            result.querySelector('h1').textContent = `You are recognized as top JavaScript fan!`;
          } else {
            result.querySelector('h1').textContent = `You have ${answers.length} right answers`;
          }

          return;
        }

        ev.target.parentNode.parentNode.parentNode
          .querySelector('li').querySelector('h2')
          .textContent = h2Questions.shift().textContent;

        p1.textContent = pAnswers.shift().textContent;
        p2.textContent = pAnswers.shift().textContent;
    };
  });
}//:(
