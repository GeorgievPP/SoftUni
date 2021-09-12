const productService = require('../services/product');
const accessoryService = require('../services/accessory');
async function init() {
    return (req, res, next) => {
        const storage = Object.assign({}, productService, accessoryService);
        req.storage = storage;
        next();

        /* ||  req.storage = {
            getAll: productService.getAll,
            getById: productService.getById,
            create: productService.create,
            edit: productService.edit,
            createComment: productService.createComment,
            createAccessory: accessoryService.createAccessory,
            getAllAccessories: accessoryService.getAllAccessories,
            attachSticker: productService.attachSticker
        }; 
        next(); */

    };
}

module.exports = init;
