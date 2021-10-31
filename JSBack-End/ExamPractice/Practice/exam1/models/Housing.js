const { Schema,model  } = require('mongoose');

const schema = new Schema({
    name: { type: String, require: [true, 'Name should be at least 6 characters'], minlength: 6 },
    type: { type: String, enum: ['Apartment', 'Villa', 'House'], require: true}, // must validate ... done
    year: { type: Number, require: [true, 'Year should be between 1850 and 2021'], min: 1850, max: 2021 },
    city: { type: String, require: [true, 'City name should be at least 4 characters long'], minlength: 4 },
    homeImage: { type: String, require: true, match: [/^https?/, 'Image must be a valid URL'] },
    propertyDescription: { type: String, require:[true, 'All fields are required'], maxLength: [60, 'Property Description must be at least 60 characters long'] },
    availablePieces: { type: Number, require: [true, 'All fields required'], min: 0, max: 10 },
    rentedHome: [{ type: Schema.Types.ObjectId, ref: 'User', default: [] }],
    owner: { type: Schema.Types.ObjectId, ref: 'User' },
    createdAt: { type: Date, default: Date.now() }
});

module.exports = model('Housing', schema);