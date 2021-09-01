const mongoose = require('mongoose');
const Cat = require('./models/Cat');
const Person = require('./models/Person');

start();

async function start() {
    const connectionStr = 'mongodb://localhost:27017/testdb';

    const client = await mongoose.connect(connectionStr, {
        useNewUrlParser: true,
        useUnifiedTopology: true
    });
    
   // console.log('Database connected');


    try {
        const someCat = new Cat({
            name: 'Fluffy',
            color: 'Green'
        });
        await someCat.save();
    } catch(err) {
        console.log('Caught the error');
        console.error('>>>', err.message);
    }


    const person = new Person({
        age: -5
    });

    try {
        await person.save();
    } catch(err) {
        console.log('Caught the error');
        console.error('>>>', err.message);
    }
/*
    const people = await Person.find({});
    people.forEach(p => p.sayHi());
    people.map(p => p.fullName).forEach(n => console.log(n));
*/


}
