const authController = require('../controllers/authController');

//Add controller
//const playController = require('../controllers/playController');

const homeController = require('../controllers/homeController');


module.exports = (app) => {
    app.use('/auth', authController);
   //Use controller
    //app.use('/play', playController);
    app.use('/', homeController);
};