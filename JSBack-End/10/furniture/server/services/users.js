const User = require('../models/User');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

async function register(email, password) {
    // check if user exist
    const existing = await User.findOne({ email });

    if (existing) {
        const err = new Error('User with this email already exist in the database');
        err.status = 404;
        throw err;
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const user = new User({
        email,
        hashedPassword
    });

    await user.save();

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
    }, 'super secret 99');
}

module.exports = {
    register,
};