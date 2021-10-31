const authController = require('../controllers/authController');

//Add controller
const postController = require('../controllers/postController');

const homeController = require('../controllers/homeController');


module.exports = (app) => {
    app.use('/auth', authController);
   //Use controller
    app.use('/post', postController);
    app.use('/', homeController);
};