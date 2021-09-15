const fs = require('fs');

module.exports = (req, res) => {
    const target = fs.createWriteStream('./uploads/demo.txt');
    req.pipe(target);
    req.on('data', data => console.log('>>>', data.toString()));

    res.writeHead(301, {
        'Location': './catalog'
    });
    res.end();
};