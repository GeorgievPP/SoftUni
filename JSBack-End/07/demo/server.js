const express = require('express');
const bodyParser = require('express').urlencoded;
const expressSession = require('express-session');


const routes = require('./controllers');
const auth = require('./auth');


const app = express();
app.use(bodyParser({ extended: false }));
app.use(expressSession({
    secret: 'my random secret',
    resave: false,
    saveUninitialized: true,
    cookie: { secure: false }
}));

app.use(auth);

routes(app);

app.post('/register', async (req, res) => {
    await req.register(req.body.username, req.body.password);
    res.redirect('/login');
});

app.post('/login', async (req, res) => {
    const username = req.body.username;
    const password = req.body.password;

    const passwordMatch = await req.login(username, password);
    if (passwordMatch) {
        res.redirect('/');
    } else {
        res.send(403, 'Wrong password');
    }
});

app.listen(3000);