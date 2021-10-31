const router = require('express').Router();

router.get('/', async (req, res) => {
    //Add it to be render
    //const plays = await req.storage.getAllPlays(req.query.orderBy);

    res.render('home', { plays }); //edit name
});

module.exports = router;