async function solution() {
    const section = document.getElementById('main');
    this.content = {};
    const articles = await getArticles();
    const ID = articles.map(id => id._id);

    for(const id of ID) {
        this.content[id] = await getContent(id);
    }

    articles.map(createArticle).forEach(article => {
        section.appendChild(article);
    });
}

window.onload = solution;

async function getArticles() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const response = await fetch(url);
    const data = await response.json();

    return data;
}

async function getContent(_id) {
    const url = `http://localhost:3030/jsonstore/advanced/articles/details/` + _id;
    const response = await fetch(url);
    const data = await response.json();

    return data.content;
}

function createArticle({_id, title}) {
    const div = createElement('div', undefined, 'accordion');
    const divHead = createElement('div', undefined, 'head', div);
    const span = createElement('span', title, undefined, divHead);
    const moreBrn = createElement('button', 'More', 'button', divHead);
    moreBrn.setAttribute('id', _id);

    const divExtra = createElement('div', undefined, 'extra', div);
    const p = createElement('p', this.content[_id], undefined, divExtra);

    moreBrn.addEventListener('click', (e) => {
        if (e.target.textContent == 'More') {
            divExtra.style.display = 'block';
            e.target.textContent = 'Less';
        } else {
            divExtra.style.display = 'none';
            e.target.textContent = 'More';
        }
    });

    return div;

}

function createElement(type, text, className, appender) {
    const element = document.createElement(type);
    if (text) {
        element.textContent = text;
    }
    if (className) {
        element.className = className;
    }
    if (appender) {
        appender.appendChild(element);
    }

    return element;
}