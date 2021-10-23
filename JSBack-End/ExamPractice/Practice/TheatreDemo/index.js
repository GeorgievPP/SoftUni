const express = require('express');

const { PORT } = require('./config');
const databaseConfig = require('./config/database');
const expressConfig = require('./config/express');


async function start() {
    const app = express();

    await databaseConfig(app);
    expressConfig(app);

    //TODO remove in production
    app.get('/', (req, res) => res.send('It works!'));

    app.listen(PORT, () => {
        console.log(`Application started at http://localhost:${PORT}`);
    });
}