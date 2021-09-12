const router = require('express').Router();

router.get('/create', (req, res) => {
    res.render('createAccessory', { title: 'Create New Accessory' });
});

router.post('/create', async (req, res) => {
    console.log(req.body);
    const accessory = {
        name: req.body.name,
        description: req.body.description,
        imageUrl: req.body.imageUrl
    };

    // try-catch like create
    await req.storage.createAccessory(accessory);

    res.redirect('/');
});

module.exports = router;