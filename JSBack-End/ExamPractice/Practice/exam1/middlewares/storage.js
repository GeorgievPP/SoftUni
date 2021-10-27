const housing = require('../services/housing');


module.exports = () => (req, res, next) => {
    // TODO import and decorate services
    req.storage = {           
        ...housing  // (destructuring) NOT TO BE req.storage.hotelServices.getHotelById(), TO BE req.storage.getHotelById()
    };

    next();
};