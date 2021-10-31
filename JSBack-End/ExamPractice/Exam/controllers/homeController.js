const router = require('express').Router();

router.get('/', async (req, res) => {
    //Add it to be render
    const posts = await req.storage.getAllPosts();

    res.render('home', { posts }); //edit name
});

module.exports = router;