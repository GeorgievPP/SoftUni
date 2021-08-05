import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { browsePage } from './views/browse.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

const main = document.querySelector('main');

page('/', decorateContext, homePage);
page('/index.html', decorateContext, homePage);
page('/browse', decorateContext, browsePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);




setUserNav();

page.start();

function decorateContext(ctx, next) {
    ctx.setUserNav = setUserNav;
    ctx.render = (content) => render(content, main);

    next();
}

function setUserNav() {
    const userId = sessionStorage.getItem('userId');
    if (userId != null) {
        [...document.querySelectorAll('nav > a.user')].forEach(a => a.style.display = 'block');
        [...document.querySelectorAll('nav > a.guest')].forEach(a => a.style.display = 'none');
    } else {
        [...document.querySelectorAll('nav > a.user')].forEach(a => a.style.display = 'none');
        [...document.querySelectorAll('nav > a.guest')].forEach(a => a.style.display = 'block');
    }
}
