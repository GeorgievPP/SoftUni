const express = require('express');

const { PORT } = require('./config');
const databaseConfig = require('./config/database');
const expressConfig = require('./config/express');

const userServices = require('./services/user');

start();

async function start() {
    const app = express();

    await databaseConfig(app);
    expressConfig(app);
    
    app.get('/', (req, res) => res.send('It works!'));
    
    app.listen(PORT, () => {
        testAuth();
        console.log(`Application started at http://localhost:${PORT}`);
    });
}       

async function testAuth() {
    try {
        const result = await userServices.createUser('Peter', '123123');
        console.log(result);

        const user = await userServices.getUserByUsername('peter');
        console.log(user);
    } catch (err) {
        console.log('Error:', err.message);
    }
}