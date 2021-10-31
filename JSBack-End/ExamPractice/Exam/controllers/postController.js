const router = require('express').Router();

const { isUser } = require('../middlewares/guards');
const { parseError } = require('../util/parsers');

router.get('/posts', async (req, res) => {
    const posts = await req.storage.getAllPosts();

    res.render('posts', { posts });
});

router.get('/create', isUser(), (req, res) => {
    res.render('post/create');
});

router.post('/create', isUser(), async (req, res) => {
    try {
        const postData = {
            title: req.body.title.trim(),
            keyword: req.body.keyword.trim(),
            createdAt: req.body.createdAt.trim(),
            imageUrl: req.body.imageUrl.trim(),
            location: req.body.location.trim(),
            description: req.body.description.trim(),
            author: req.user._id
        };

        await req.storage.createPost(postData); 

        res.redirect('/');

    } catch (err) {

        console.log(err.message);

        const ctx = {
            errors: parseError(err),
            postData: {
                title: req.body.title.trim(),
                keyword: req.body.keyword.trim(),
                createdAt: req.body.createdAt.trim(),
                imageUrl: req.body.imageUrl.trim(),
                location: req.body.location.trim(),
                description: req.body.description.trim(),
            }
        };
        res.render('post/create', ctx);
    }
});


// TYKA !
router.get('/details/:id', async (req, res) => {
    try {
        const post = await req.storage.getPostById(req.params.id);
        post.hasUser = Boolean(req.user);
        post.isAuthor = req.user && req.user._id == post.author._id;
        post.liked = req.user && post.votes.find(u => u._id == req.user._id);
        console.log(post.votes);
        res.render('post/details', { post });
    } catch (err) {
        console.log(err.message);
        res.redirect('/404');
    }
});

router.get('/edit/:id', isUser(), async (req, res) => {
    try {
        const post = await req.storage.getPostById(req.params.id);

        if (post.author._id != req.user._id) {
            throw new Error('Cannot edit post you haven\'t created');
        }
        const ctx = {
            postData: {
                _id: req.params.id,
                title: post.title.trim(),
                keyword: post.keyword.trim(),
                createdAt: post.createdAt.trim(),
                imageUrl: post.imageUrl.trim(),
                location: post.location.trim(),
                description: post.description.trim(),
            }
        };

        res.render('post/edit', ctx);
    } catch (err) {
        console.log(err);
        res.redirect('/post/details/' + req.params.id);
    }
});

router.post('/edit/:id', isUser(), async (req, res) => {
    try {
        const play = await req.storage.getPostById(req.params.id);

        if (play.author._id != req.user._id) {
            throw new Error('Cannot edit post you haven\'t created');
        }

        await req.storage.editPost(req.params.id, req.body);

        res.redirect('/');

    } catch (err) {
        const ctx = {
            errors: parseError(err),
            postData: {
                _id: req.params.id,
                title: req.body.title.trim(),
                keyword: req.body.keyword.trim(),
                createdAt: req.body.createdAt.trim(),
                imageUrl: req.body.imageUrl.trim(),
                location: req.body.location.trim(),
                description: req.body.description.trim(),
            }
        };

        res.render('post/edit', ctx);
    }
});

router.get('/delete/:id', isUser(), async (req, res) => {
    try {
        const post = await req.storage.getPostById(req.params.id);

        if (post.author._id != req.user._id) {
            throw new Error('Cannot delete post you haven\'t created');
        }

        await req.storage.deletePost(req.params.id);
        res.redirect('/');
    } catch (err) {
        console.log(err);
        res.redirect('/post/details/' + req.params.id);
    }
});

router.get('/like/:id', isUser(), async (req, res) => {
    try {
        const post = await req.storage.getPostById(req.params.id);

        if (post.author == req.user._id) {
            throw new Error('Cannot like your own post');
        }

        await req.storage.likePost(req.params.id, req.user._id);
        res.redirect('/post/details/' + req.params.id);
    } catch (err) {
        console.log(err);
        res.redirect('/post/details/' + req.params.id);
    }
});

router.get('/unlike/:id', isUser(), async (req, res) => {
    try {
        const post = await req.storage.getPostById(req.params.id);

        if (post.author == req.user._id) {
            throw new Error('Cannot unlike your own post');
        }

        await req.storage.unlikePost(req.params.id, req.user._id);
        res.redirect('/post/details/' + req.params.id);
    } catch (err) {
        console.log(err);
        res.redirect('/post/details/' + req.params.id);
    }
});




router.get('/profile', isUser(), async (req, res) => {
    const posts = await req.storage.getProfile(req.user._id);
    res.render('profile', { posts });
});

module.exports = router;