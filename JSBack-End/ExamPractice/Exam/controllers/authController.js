const router = require('express').Router();
const { body, validationResult } = require('express-validator');

const { isGuest } = require('../middlewares/guards');

router.get('/register', isGuest(), (req, res) => {
    res.render('register');
});

router.post(
    '/register',
    isGuest(),
    body('firstName')
        .isLength({ min: 3 }).withMessage('First Name must be at least 3 characters long').bail()
        .isAlpha().withMessage('First Name must contain only English letters'),
    body('lastName')
        .isLength({ min: 5 }).withMessage('Last Name must be at least 3 characters long').bail()
        .isAlpha().withMessage('Last Name must contain only English letters'),
    body('password')
        .isLength({ min: 4 }).withMessage('Password must be at least 4 characters long'),
    body('rePass').custom((value, { req }) => {
        if (value != req.body.password) {
            throw new Error('Password don\'t match');
        }
        return true;
    }),
    async (req, res) => {
        const { errors } = validationResult(req);
        try {
            if (errors.length > 0) {
                throw new Error(Object.values(errors).map(e => e.msg).join('\n'));
            }

            await req.auth.register(req.body.firstName.trim(), req.body.lastName.trim(), req.body.email.trim(), req.body.password.trim());

            res.redirect('/');  // TODO change redirect location
        } catch (err) {
            console.log(err.message);
            const ctx = {
                errors: err.message.split('\n'),
                userData: {
                    firstName: req.body.firstName,
                    lastName: req.body.lastName,
                    email: req.body.email
                }
            };
            console.log(ctx.userData);
            res.render('register', ctx);
        }
    }
);


router.get('/login', isGuest(), (req, res) => {
    res.render('login');
});

router.post('/login', isGuest(), async (req, res) => {
    try {
        await req.auth.login(req.body.email.trim(), req.body.password.trim());

        res.redirect('/');  // TODO change redirect location

    } catch (err) {
        console.log(err.message);
        let errors = [err.message];
        
      /*  if (err.type == ['credential']) {
            errors = ['Incorrect email or password'];
        }*/

        const ctx = {
            errors,
            userData: {
                email: req.body.email
            }
        };
        res.render('login', ctx);
    }
});

router.get('/logout', (req, res) => {
    req.auth.logout();
    res.redirect('/');
});

module.exports = router;