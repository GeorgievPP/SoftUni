async function solution() {
    const section = document.getElementById('main');
    this.content = {};
    const articles = await getArticles();
    const ids = articles.map(id => id._id);

    for(const id of ids) {
        this.content[id] = await getContent(id);
    }

    articles.map(createArticle).forEach(article => {
        section.appendChild(article);
    });
}

window.onload = solution;

async function getArticles() {
    const urlArticles = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const response = await fetch(urlArticles);
    const dataArticles = await response.json();

    return dataArticles;
}

async function getContent(_id) {
    const urlContent = `http://localhost:3030/jsonstore/advanced/articles/details/` + _id;
    const response = await fetch(urlContent);
    const dataContent = await response.json();

    return dataContent.content;
}

function createArticle({_id, title}) {
    const div = e('div', undefined, 'accordion');
    const divHead = e('div', undefined, 'head');
    div.appendChild(divHead);

    const span = e('span', title, undefined);
    divHead.appendChild(span);

    const moreBtn = e('button', 'More', 'button');
    divHead.appendChild(moreBtn);
    moreBtn.setAttribute('id', _id);

    const divExtra = e('div', undefined, 'extra');
    div.appendChild(divExtra);

    const p = e('p', this.content[_id], undefined);
    divExtra.appendChild(p);
    moreBtn.addEventListener('click', (e) => {
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

function e(type, text, className) {
    const element = document.createElement(type);
    if (text) {
        element.textContent = text;
    }
    if (className) {
        element.className = className;
    }

    return element;
}