import { html } from '../../node_modules/lit-html/lit-html.js';

import { getAllListings } from '../api/data.js';

const dashboardTemplate = (books) => html`
<!-- Dashboard Page ( for Guests and Users ) -->
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    ${books.length == 0 ? html`<p class="no-books">
        No books in database!
    </p>`: html`
    <ul class="other-books-list">
        ${books.map(bookTemplate)}
    </ul>` }
</section>`;




const bookTemplate = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <a class="button" href='/details/${book._id}'>Details</a>
    </li>`;

export async function dashboardPage(ctx) {
    const books = await getAllListings();
    console.log(books);

    ctx.render(dashboardTemplate(books));
}
