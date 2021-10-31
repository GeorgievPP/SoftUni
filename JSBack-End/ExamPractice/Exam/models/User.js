const { Schema, model } = require('mongoose');

// user only this ?

const schema = new Schema({
    firstName: { type: String, required: true },
    lastName: { type: String, required: true },
    email: { type: String, required: true },
    hashedPassword: { type: String, required: true },
    posts: [{ type: Schema.Types.ObjectId, ref: 'Post' }]
});

module.exports = model('User', schema);