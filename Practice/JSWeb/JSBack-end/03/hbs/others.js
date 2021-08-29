
app.get('/', (req, res) => {
    const ctx = {
        user: {
            username: 'Peter'
        },
        title: 'Home Page',
        name: 'Peter',
        age: 24,
        items: [
            {
                type: "Lint",
                qty: 5
            },
            {
                type: "Wallet",
                qty: 1
            },
            {
                type: "Bubblegum",
                qty: 10
            },
            {
                type: "Spare coin",
                qty: 3.5
            }
        ]
    };
    res.render('home', ctx);
});

app.get('/catalog', (req, res) => {
    res.render('catalog', { products: [
        {
            type: 'Washer',
            qty: 45
        },
        {
            type: 'Bolt',
            qty: 118
        }
    ]});
})
