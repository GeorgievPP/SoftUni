import {setupCatalog, showCatalog} from './catalog.js';
import { setupLogin, showLogin } from './login.js';


main();

function main() {
    setUserNav();

    const main = document.querySelector('main');
    const catalogSection = document.getElementById('catalogSection');
    const loginSection = document.getElementById('loginSection');

    const links = {
        'catalogLink': showCatalog,
        'loginLink': showLogin
    };
    
    setupCatalog(main, catalogSection);
    setupLogin(main, loginSection);

    setupNavigation();
    
    // Start application in catalog view
    showCatalog();

    function setupNavigation() {
        document.querySelector('nav').addEventListener('click', (event) => {
            if (event.target.tagName == 'A') {  
                const view = links[event.target.id];
                if (typeof view == 'function') {
                   event.preventDefault();
                   view();
                }
            }
        });
    }
}

function setUserNav() {
    
    if (sessionStorage.getItem('authToken') != null) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('logoutBtn').addEventListener('click', logout);
    } else {
        document.getElementById('guest').style.display = 'inline-block';
    }
}

async function logout() {
    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: {
            'X-Authorization': sessionStorage.getItem('authToken')
        },
    });
    if (response.status == 200) {
        sessionStorage.removeItem('authToken');
        window.location.pathname = 'index.html';
    } else {
        console.error(await response.json());
    }
}




/*
window.addEventListener('load', async () => {
    if (sessionStorage.getItem('authToken') != null) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('logoutBtn').addEventListener('click', logout);
    } else {
        document.getElementById('guest').style.display = 'inline-block';
    }


    const recipes = await getRecipes();
    const cards = recipes.map(createRecipePreview);

    main.innerHTML = '';
    cards.forEach(c => main.appendChild(c));
});


*/
