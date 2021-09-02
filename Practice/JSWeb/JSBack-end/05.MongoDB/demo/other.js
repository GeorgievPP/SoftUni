
// Using mongodb

const { MongoClient } = require('mongodb');

const connectionStr = 'mongodb://localhost:27017';

const client = new MongoClient(connectionStr, {
    useUnifiedTopology: true
});

client.connect(async (err) => {
    if (err != null) {
        console.log('Something unexpected happened');
        return;
    }

    console.log('Database connected');

    const db = client.db('testdb');
    const collection = db.collection('cats');
    const data = await collection.find({}).toArray();
    console.log(data);
});


// Create

const person = new Person({
    firstName: 'John',
    lastName: 'Smith',
    age: 29
});
person.save();

const person1 = new Person({
    firstName: 'Peter',
    lastName: 'Jackson',
    age: 34
});
person1.save();

// UPDATE

await Person.findByIdAndUpdate('6130930864e1fbf3ba6a4b64', {
    $set: {
        lastName: 'Ryan',
        age: 31
    }
});

console.log(await Person.find({}));



await Person.updateOne({ firstName: 'John' }, {
    $set: {
        lastName: 'Stavros',
        age: 44
    }
});

console.log(await Person.find({}));


const person = await Person.findOne(({ firstName: 'John', age: { $gt: 30 } }));
person.age++;
await person.save();



// Sort

const people = await Person.find({}).sort({ age: 1 }).skip(2).limit(2);
console.log(people);

// other create

const post = new Post({
    author: person,
    title: 'New Post',
    content: 'This is post content'
});
await post.save();


const comment = new Comment({
    author: post.author,
    content: 'First comment',
    post
});
await comment.save();

post.comments.push(comment);

await post.save();