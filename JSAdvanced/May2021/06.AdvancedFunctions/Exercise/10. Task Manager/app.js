function solve() {
    let displayMovie = document.querySelector('#movies ul');
    let archive = document.querySelector('#archive ul');
    archive.nextElementSibling.addEventListener('click', () => archive.innerHTML = null);  // clear archive
    document.querySelector('button').addEventListener('click', addMovieOnScreen);
 
    function addMovieOnScreen(e) {
        e.preventDefault();
        let [name, hall, price] = document.querySelectorAll('#container input');
 
        if (name.value && hall.value && Number(price.value) || price.value === '0') {
 
            displayMovie.innerHTML +=
                `<li>
                    <span>${name.value}</span>
                    <strong>Hall: ${hall.value}</strong>
                    <div>
                      <strong>${price.value}</strong>
                      <input placeholder="Tickets Sold">
                      <button>Archive</button>
                    </div>
                </li>`
 
            name.value = null;
            hall.value = null;
            price.value = null;
 
        }
 
        Array.from(displayMovie.querySelectorAll('button')).forEach(btn => btn.addEventListener('click', addToArchive));
 
        function addToArchive(btn) {
 
            let ticketPrice = btn.target.parentNode.children[0];
            let ticketsSold = btn.target.parentNode.children[1];
 
            if (Number(ticketsSold.value) || ticketsSold.value === '0') {
 
                archive.innerHTML +=
                    `<li>
                        <span>${btn.target.parentNode.parentNode.children[0].textContent}</span>
                        <strong>Total amount: ${(ticketPrice.textContent * ticketsSold.value).toFixed(2)}</strong>
                        <button>Delete</button>
                    </li>`
 
                btn.target.parentNode.parentNode.remove(); // remove movie from screen
                Array.from(archive.querySelectorAll('button')).forEach(btn => btn.addEventListener('click', (btn) => btn.target.parentNode.remove())); // remove  movie from archive
 
            }
        }
    }
}



/*function solve() {
    const [section1, section2, section3, section4] = document.querySelectorAll('section');
    const taskName = document.getElementById('task');
    const taskDate = document.getElementById('date');
    const taskDescrip = document.getElementById('description');

    const addBtn = section1.children[1].querySelector('button');
    addBtn.addEventListener('click', onAdd);

    function onAdd(ev) {
        ev.preventDefault();

        if (taskName.value == '' || taskDate.value == '' || taskDescrip.value == '') {
            return;
        }

        const article = createElement('article', null, null);
        const h3 = createElement('h3', taskName.value, null);
        const pDescription = createElement('p', `Description: ${taskDescrip.value}`);
        const pDate = createElement('p', `Due Date: ${taskDate.value}`, null);
        const buttonsDiv = createElement('buttonsDiv', null, 'flex');
        const buttonStart = createElement('button', 'Start', 'green');
        const buttonDelete = createElement('button', 'Delete', 'red');
        const buttonFinish = createElement('button', 'Finish', 'orange');

        buttonStart.addEventListener('click', () => {
            section3.children[1].appendChild(article);
            buttonStart.remove();
            buttonsDiv.appendChild(buttonFinish);
        });

        buttonFinish.addEventListener('click', () => {
            section4.lastElementChild.appendChild(article);
            buttonsDiv.remove();
        });

        buttonDelete.addEventListener('click', () => {
            article.remove();
        });

        [h3, pDescription, pDate, buttonsDiv].forEach((el) => {
            article.appendChild(el);
        });

        [buttonStart, buttonDelete].forEach((el) => {
            buttonsDiv.appendChild(el);
        })

        section2.children[1].appendChild(article);

        [taskName, taskDate, taskDescrip].forEach((el) => el.value = '');
    }

    function createElement(type, content, className) {
        const el = document.createElement(type);
        if (content) {
            el.textContent = content;
        } if (className) {
            el.className = className;
        }
        return el;
    }
}*/