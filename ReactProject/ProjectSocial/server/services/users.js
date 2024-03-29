const User = require('../models/User');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SECRET } = require('../config');

async function register(username, email, password) {
    // check if user exist
    const existing = await User.findOne({ email });

    if (existing) {
        const err = new Error('User with this email already exist in the database');
        err.status = 409;
        throw err;
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const user = new User({
        username,
        email,
        hashedPassword
        /*
         username: req.body.username,
      email: req.body.email,
      password: hashedPassword,
      profilePicture: req.body.profilePicture,
      profilePicture: req.body.profilePicture,
      coverPicture: req.body.coverPicture,
      desc:  req.body.desc,
      coverPicture: req.body.coverPicture,
      desc:  req.body.desc,   
      city:  req.body.city,
      from: req.body.from,
      relationship:  req.body.relationship,
        */
    });

    await user.save();

    return {
        _id: user._id,
        username: user.username,
        email: user.email,
        accessToken: createToken(user)
    };
}

async function login(email, password) {
    const user = await User.findOne({ email });

    if (!user) {
        const err = new Error('Incorrect email or password');
        err.status = 401;
        throw err;
    }

    const match = await bcrypt.compare(password, user.hashedPassword);

    if(!match) {
        const err = new Error('Incorrect email or password');
        err.status = 401;
        throw err;
    }

    return {
        _id: user._id,
        email: user.email,
        accessToken: createToken(user)
    };
}

function createToken(user) {
    const token = jwt.sign({
        _id: user._id,
        email: user.email
    }, SECRET);

    return token;
}

module.exports = {
    register,
    login
};