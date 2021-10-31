const { Schema, model } = require('mongoose');

const schema = new Schema({
    title: { type: String, required: true, minlength: 6 },
    keyword: { type: String, required: true, minlength: 6 },
    location: { type: String, required: true, maxLength: 10 },
    createdAt: { type: String, required: true, match: /^[0-9]{2}\.[0-9]{2}\.[0-9]{4}$/ },
    imageUrl: { type: String, required: true, match: /^https?/ },
    description: { type: String, required: true, minlength: 8 },
    author: { type: Schema.Types.ObjectId, ref: 'User' },
    votes: [{ type: Schema.Types.ObjectId, ref: 'User', default: [] }],
    rating: { type: Number, default: 0}
});

module.exports = model('Post', schema);