const User = require('../models/User');

async function createUser(fullName, username, hashedPassword) {
    // TODO adapt properties to project requirements

    const user = new User({
        fullName,
        username,
        hashedPassword
    });

    await user.save();

    return user;
}

async function getUserByUsername(username) {
    const pattern = new RegExp(`^${username}$`, 'i');
    const user = await User.findOne({ username: { $regex: pattern } });
    return user;
}

//TODO add function for find user by other properties, as specified in the project requirements

module.exports = {
    createUser,
    getUserByUsername
};