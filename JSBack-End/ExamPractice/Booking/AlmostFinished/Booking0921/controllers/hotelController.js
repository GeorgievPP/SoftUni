const router = require('express').Router();
const { isUser } = require('../middlewares/guards');

router.get('/create', isUser(), async (req, res) => {
    res.render('hotel/create');
});

router.post('/create', isUser(), async (req, res) => {
    const hotelData = {
        name: req.body.name,
        city: req.body.city,
        imageUrl: req.body.imageUrl,
        rooms: req.body.rooms,
        bookedBy: [],
        owner: req.user._id
    };

    try {
        await req.storage.createHotel(hotelData);

        res.redirect('/');
    } catch (err) {
        console.log(err.message);

        let errors;
        if (err.errors) {
            errors = Object.values(err.errors).map(e => e.properties.message);
        } else {
            errors = [err.message];
        }

        const ctx = {
            errors,
            hotelData: {
                name: req.body.name,
                city: req.body.city,
                imageUrl: req.body.imageUrl,
                rooms: req.body.rooms
            }
        };

        res.render('hotel/create', ctx);
    }
});

module.exports = router;