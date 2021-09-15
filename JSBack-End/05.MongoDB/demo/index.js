const mongoose = require('mongoose');
const Cat = require('./models/Cat');
const Comment = require('./models/Comment');
const Person = require('./models/Person');
const Post = require('./models/Post');

start();

async function start() {
    const connectionStr = 'mongodb://localhost:27017/testdb';

    const client = await mongoose.connect(connectionStr, {
        useNewUrlParser: true,
        useUnifiedTopology: true
    });
    
    console.log('Database connected');

    const post = await Post.findOne({}).populate('author').populate({
        path: 'comments',
        populate: 'author'
    });

    console.log(post);
    
}
