import { html } from '../../node_modules/lit-html/lit-html.js';

import { deleteListing, getListingById } from '../api/data.js';

const detailsTemplate = (book, isOwner, onDelete) => html`
<!-- Details Page ( for Guests and Users ) -->
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <div class="actions">
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            ${isOwner ? html`
            <a class="button" href="/edit/${book._id}">Add Worker</a>
            <a class="button" href="/edit/${book._id}">Edit</a>
            <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>` 
            : html`<a class="button" href="#">Like</a>`}

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: 0</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
    <div class="book-description">
        <h3>Workers:</h3>
        <p>${book.workers}</p>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const bookId = ctx.params.id;
    const book = await getListingById(bookId);
    console.log(book);

    const isOwner = ctx.user && book._ownerId == ctx.user._id;
    const notOwner = ctx.user == true;
    ctx.render(detailsTemplate(book, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure?');
        if (confirmed) {
            await deleteListing(bookId);
            ctx.page.redirect('/catalog');
        }
    }

}