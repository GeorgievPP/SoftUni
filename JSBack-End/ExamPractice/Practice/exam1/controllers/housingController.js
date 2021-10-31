
const router = require('express').Router();

const { isUser } = require('../middlewares/guards');


router.get('/', async (req, res) => {
   //const housings = await req.storage.getTopHousings();
    const housings = await req.storage.getAllHousings();
    res.render('housing/rent', { housings });
});


router.get('/create', isUser(), async (req, res) => {
    res.render('housing/create');
});


router.post('/create', isUser(), async (req, res) => {
    const housingData = {
        name: req.body.name,
        type: req.body.type,
        city: req.body.city,
        year: req.body.year,
        homeImage: req.body.homeImage,
        propertyDescription: req.body.propertyDescription,
        availablePieces: req.body.availablePieces,
        rentedHome: [],
        owner: req.user._id
    };

    try {
        await req.storage.createHousing(housingData);

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
            housingData: {
                name: req.body.name,
                type: req.body.type,
                city: req.body.city,
                year: req.body.year,
                homeImage: req.body.homeImage,
                propertyDescription: req.body.propertyDescription,
                availablePieces: req.body.availablePieces
            }
        };

        res.render('housing/create', ctx);
    }
});

router.get('/details/:id', async (req, res) => {
    try {
        const housing = await req.storage.getHousingById(req.params.id);
        housing.hasUser = Boolean(req.user);
        housing.isAuthor = req.user && req.user._id == housing.owner;
        housing.isAvailable =  req.user && housing.availablePieces > 0;
        housing.isBook = req.user && housing.rentedHome.find(x => x == req.user._id);
        housing.tenants = housing.rentedHome.map(x => x.name).join(', ');
 
        

        res.render('housing/details', { housing });
    } catch (err) {
        console.log(err.message);
        res.redirect('/404');
    }
});


router.get('/edit/:id', isUser(), async (req, res) => {
    try {
        const housing = await req.storage.getHousingById(req.params.id);

        if (housing.author != req.user._id) {
            throw new Error('Cannot edit play you haven\'t created');
        }

        res.render('housing/edit', { play });
    } catch (err) {
        console.log(err);
        res.redirect('/housing/details/' + req.params.id);
    }
});


router.post('/edit/:id', isUser(), async (req, res) => {
    try {
        const housing = await req.storage.getHousingById(req.params.id);
       
        if (housing.author != req.user._id) {
            throw new Error('Cannot edit play you haven\'t created');
        }

        await req.storage.editHousing(req.params.id, req.body);

        res.redirect('/');

    } catch (err) {
        const ctx = {
            errors: parseError(err),
            housing: {
                _id: req.params.id,
                name: req.body.name,
                type: req.body.type,
                city: req.body.city,
                year: req.body.year,
                homeImage: req.body.homeImage,
                propertyDescription: req.body.propertyDescription,
                availablePieces: req.body.availablePieces
            }
        };

        res.render('housing/edit', ctx);
    }
});

router.get('/delete/:id', isUser(), async (req, res) => {
    try {
        const housing = await req.storage.getHousingById(req.params.id);

        if (housing.author != req.user._id) {
            throw new Error('Cannot delete play you haven\'t created');
        }

        await req.storage.deleteHousing(req.params.id);
        res.redirect('/');
    } catch (err) {
        console.log(err);
        res.redirect('/housing/details/' + req.params.id);
    }
});


router.get('/book/:id', isUser(), async (req, res) => {
    try {
        await req.storage.bookHousing(req.params.id, req.user._id);

        res.redirect('/hotels/details/' + req.params.id);

    } catch (err) {
        console.log(err.message);
        res.redirect('/');
    }
});


module.exports = router;
