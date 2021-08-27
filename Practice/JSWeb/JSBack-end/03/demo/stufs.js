app.get('/about', (req, res) => {
    res.send('About page');
});

app.get('/catalog/:productId/details', (req, res) => {
    console.log(req.params.productId);
    res.send('Product Page');
});

app.route('/catalog')
    .get('/catalog', (req, res) => {
        res.send('Catalog Page');
    })
    .post('/catalog', (req, res) => {
        res.status(201);
        res.send('Article created');
    });
    

app.all('*', (req, res) => {
    res.status(404);
    res.send('404 Not Found');
});