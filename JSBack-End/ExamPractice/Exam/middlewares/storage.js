// TODO import and decorate services
const postServices = require('../services/post');


module.exports = () => (req, res, next) => {
    req.storage = {
        ...postServices
    };

    next();
};