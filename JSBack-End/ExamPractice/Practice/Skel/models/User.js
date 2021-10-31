const { Schema, model } = require('mongoose');

// user only this ?

const schema = new Schema({
    username: { type: String, required: true },
    hashedPassword: { type: String, required: true },
    //likedPlays: [{ type: Schema.Types.ObjectId, ref: 'Play' }]
});

module.exports = model('User', schema);