// TODO import and decorate services
//const playService = require('../services/play');


module.exports = () => (req, res, next) => {
    req.storage = {
       // ...playService     OR    
    };
    
    next();
};