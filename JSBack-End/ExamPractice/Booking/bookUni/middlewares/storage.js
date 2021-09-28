const hotel = require('../services/hotel');


module.exports = () => (req, res, next) => {
    // TODO import and decorate services
    req.storage = {           
        ...hotel  // (destructuring) NOT TO BE req.storage.hotelServices.getHotelById(), TO BE req.storage.getHotelById()
    };

    next();
};