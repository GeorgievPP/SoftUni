const express = require('express');
const cookieParser = require('cookie-parser');


module.exports = (app) => {
   
    app.use(cookieParser());
   // app.use(authMiddleware());
   // app.use(storageMiddleware());

    app.use((req, res, next) => {
        if (!req.url.includes('favicon')) {
            console.log('>>>', req.method, req.url);

            if (req.user) {
                console.log('Known user', req.user.email);
            }
        }

        next();
    });

};