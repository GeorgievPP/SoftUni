const express = require('express');
const hbs = require('express-handlebars');

const app = express();

app.engine('.hbs', hbs ({
    partialsDir: './views',
    extname: '.hbs'
}));

app.set('view engine', '.hbs');

app.get('/', (req, res) => {
    //res.send('It\'s working');
    res.render('home.hbs');
});

app.listen(3000);