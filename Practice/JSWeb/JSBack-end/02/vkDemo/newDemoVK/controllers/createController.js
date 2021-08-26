const parseForm = require('../util/formParser');
const database = require('../util/database');

module.exports = async (req, res) => {
    const body = await parseForm(req);

    console.log('Create Item');

    database.addItem(body);

    res.writeHead(301, {
        'Location': '/catalog'
    });
    res.end();

};