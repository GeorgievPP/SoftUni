const { Schema, model } = required('mongoose');

const schema = new Schema({
    title: { type: String, required: [true, 'Title is required'] },
    description: { type: String, required: [true, 'Description is required'], maxLength: [50, 'Description must be at least 50 characters long'] },
    imageUrl: { type: String, required: [true, 'Image is required'] },
    public: { type: Boolean, required: true, default: false },
    createdAt: { type: Date, default: Date.now },
    userLiked: [ { type: Schema.Types.ObjectId, ref: 'User', default: [] } ],
    author: { type: Schema.Types.ObjectId, ref: 'User' }
});

module.exports = model('Play', schema);
