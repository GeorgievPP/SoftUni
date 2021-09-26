const Play = require('../models/Play');

async function getAllPlays() {
    return Play.find({ public: true }).sort({ createAt: -1 }).lean(); // without await? yes, no problem: with, without.... filter : true
}

async function getPlayById(id) {
    return Play.findById(id).lean();
}

async function createPlay(playData) {
    const pattern = new RegExp(`^${playData.title}$`, 'i');
    const existing = await Play.find({ title: { $regex: pattern } });

    if (existing) {
        throw new Error('A play with this name already exists!');
    }

    const play = new Play(playData);

    await play.save();

    return play;
}

async function editPlay(id, playData) {

}

async function deletePlay(id) {

}

module.exports = {
    getAllPlays,
    getPlayById,
    createPlay,
    editPlay,
    deletePlay
};