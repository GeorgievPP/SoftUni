const { Schema,model  } = require('mongoose');

const schema = new Schema({
    name: { type: String, require: true},
    type: { type: String, require: true},
    year: { type: Number, require: true},
    city: { type: String, require: true},
    homeImage: { type: String, require: true},
    propertyDescription: { type: String, require: true},
    availablePieces: { type: Number, require: true},
    rentedHome: [{ type: Schema.Types.ObjectId, ref: 'User' }],
    owner: { type: Schema.Types.ObjectId, ref: 'User' }
});

module.exports = model('Housing', schema);