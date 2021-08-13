import { html } from '../../node_modules/lit-html/lit-html.js';

import { createListing } from '../api/data.js';

const createTemplate = (userEmail, onSubmit) => html`
<!-- Create Page ( Only for logged-in users ) -->
<section id="create-page" class="create">
    <form @submit=${onSubmit} id="create-form" action="" method="">
        <fieldset>
            <legend>Add new Work</legend>
            <p class="field">
                <label for="author">Author</label>
                <span class="input">
                    <input type="text" name="author" id="author" value=${userEmail}>
                </span>
            </p>
            <p class="field">
                <label for="address">Address</label>
                <span class="input">
                    <input type="text" name="address" id="address" placeholder="Address">
                </span>
            </p>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="workers">Workers</label>
                <span class="input">
                    <textarea name="workers" id="workers" placeholder="Workers"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="hours">Hours</label>
                <span class="input">
                    <input type="number" name="hours" id="hours" placeholder="Hours">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Apartment">Apartment</option>
                        <option value="Factory">Factory</option>
                        <option value="House">House</option>
                        <option value="Restaurant">Restaurant</option>
                        <option value="Stairway">Stairway</option>
                        <option value="Warehouse">Warehouse</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Work">
        </fieldset>
    </form>
</section>`;

export async function createPage(ctx) {
    console.log(ctx);
    const userEmail = ctx.user.email;
    ctx.render(createTemplate(userEmail, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        const author = formData.get('author');
        const address = formData.get('address');
        const title = formData.get('title');
        const description = formData.get('description');
        const workers = formData.get('workers');
        const imageUrl = formData.get('imageUrl');
        const hours = Number(formData.get('hours'));
        const type = formData.get('type');

        if (!author || !address || !title || !description || !workers || !imageUrl || !hours || !type) {
            return alert('All fields are required');
        }

        await createListing({
            author,
            address,
            title,
            description,
            workers,
            imageUrl,
            hours,
            type
        });

        ctx.page.redirect('/catalog');

    }
}