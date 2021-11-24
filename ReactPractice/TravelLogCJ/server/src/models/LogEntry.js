const mongoose = require('mongoose');

const { Schema, model } = mongoose;

const requiredString = {
    type: String,
    required: true,
};

const requiredNumber = {
    type: Number,
    required: true,
};

const logEntrySchema = new Schema({
    title: requiredString,
    description: String,
    image: String,
    comments: String,
    rating: { type: Number, min: 0, max: 10, default: 0, },
    latitude: {
        ...requiredNumber,
        min: -90,
        max: 90,
    },
    longitude: {
        ...requiredNumber,
        min: -180,
        max: 180,
    },
    visitDate: {
        required: true,
        type: Date,
    },
}, {
    timestamps: true,
});

const LogEntry = model('LogEntry', logEntrySchema);

module.exports = LogEntry;