import { html } from '../../node_modules/lit-html/lit-html.js';
import { getFurniture } from '../api/data.js';
import { itemTemplate } from './common/item.js';

const dashboardTemplate = (data, search, onSearch) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
        <div style="float:right">
            <input id="searchInput" name="search" type="text" .value=${search}>
            <button @click=${onSearch}>Search</button>
        </div>
    </div>
</div>
<div class="row space-top">
    ${data.map(itemTemplate)}
</div>`;

export async function dashboardPage(ctx) {
    const searchParams = ctx.querystring.split('=')[1];

    const data = await getFurniture(searchParams);
    ctx.render(dashboardTemplate(data, searchParams, onSearch));

    function onSearch(event) {
        const search = encodeURIComponent(document.getElementById('searchInput').value);
        ctx.page.redirect('/?search=' + search);
    }
}