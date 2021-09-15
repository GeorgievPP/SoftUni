const mongoose = require('mongoose');


const catSchema = new mongoose.Schema({
    name: { 
        type: String, 
        required: true ,
        validate: {
            validator: function(value) {
                const letter = value.slice(0, 1);
                return letter === letter.toLocaleUpperCase();
            }, 
            message: 'Name must began with capital letter - {VALUE}'
        }
    },
    color: { 
        type: String, 
        required: true,
        enum: {
            values: ['Grey', 'Orange', 'White', 'Black', 'Mixed'],
            message: 'Color must be one of Grey, Orange, White, Black or Mixed'
        }
    }
});
const Cat = mongoose.model('Cat', catSchema);

module.exports = Cat;