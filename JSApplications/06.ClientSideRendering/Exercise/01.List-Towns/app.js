import { html, render } from './node_modules/lit-html/lit-html.js';

const listTemplate = (data) => html`
<ul>
    ${data.map(t => html`<li>${t}</li>`)}
</ul>`;

//add click listener
document.getElementById('btnLoadTowns').addEventListener('click', updateList);

function updateList(event) {
    event.preventDefault();
    //parse input
    const townsAsStrings = document.getElementById('towns').value;
    const towns = townsAsStrings.split(',').map(x => x.trim());
    const root = document.getElementById('root');

    //execute template
    const result = listTemplate(towns);
    //render result
    render(result, root);
}

