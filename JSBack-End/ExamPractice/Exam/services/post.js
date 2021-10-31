const Post = require('../models/Post');

async function getAllPosts() {

    return Post.find({}).lean();
}

async function getPostById(id) {
    return Post.findById(id).populate('votes').populate('author').lean();
}

async function createPost(postData) {
    const pattern = new RegExp(`^${postData.title}$`, 'i');
    const existing = await Post.findOne({ title: { $regex: pattern } });

    if (existing) {
        throw new Error('A post with this title already exists!');
    }

    const post = new Post(postData);

    await post.save();

    return post;
}

async function editPost(id, postData) {
    const post = await Post.findById(id);

    post.title = postData.title.trim();
    post.keyword = postData.keyword.trim();
    post.location = postData.location.trim();
    post.imageUrl = postData.imageUrl.trim();
    post.description = postData.description.trim();

    return post.save();
}

async function deletePost(id) {
    return Post.findByIdAndDelete(id);
}

async function likePost(postId, userId) {
    const post = await Post.findById(postId);

    post.votes.push(userId);
    post.rating++;

    return post.save();
}
async function unlikePost(postId, userId) {
    const post = await Post.findById(postId);

    post.votes.push(userId);
    post.rating--;

    return post.save();
}

async function getProfile(userId) {
    return await Post.find({ author: userId}).populate('author').lean();
}

module.exports = {
    getAllPosts,
    getPostById,
    createPost,
    editPost,
    deletePost,
    likePost,
    unlikePost,
    getProfile
};