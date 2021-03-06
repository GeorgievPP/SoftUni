import {e} from './dom.js';
import {showDetails} from './details.js';


 async function getRecipes() {
    const response = await fetch('http://localhost:3030/data/recipes');
    const recipes = await response.json();

    return recipes;
}


 function createRecipePreview(recipe) {
    const result = e('article', { className: 'preview', onClick: () => showDetails(recipe._id) },
        e('div', { className: 'title' }, e('h2', {}, recipe.name)),
        e('div', { className: 'small' }, e('img', { src: recipe.img })),
    );

    return result;
}




let main;
let section;
let setActiveNav;

// setup function
export function setupCatalog(mainTarget, sectionTarget, setActiveNavCb) {
    // - store section reference
    // - store main element  reference
    // - initialize event listeners (if required)

    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCb;
}

// display function
export async function showCatalog() {

    setActiveNav('catalogLink');

    section.innerHTML = '<p style="color: white">Loading...</p>';
    main.innerHTML = '';
    main.appendChild(section);
    // - fetch data (if required)
    // - clear main element HTML
    // - attach section

    const recipes = await getRecipes();
    const cards = recipes.map(createRecipePreview);

    const fragment = document.createDocumentFragment();
    cards.forEach(c => fragment.appendChild(c));

    section.innerHTML = '';
    section.appendChild(fragment);

}