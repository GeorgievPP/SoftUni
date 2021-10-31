const Housing = require('../models/Housing');

async function createHousing(housingData) {
    const housing = new Housing(housingData);
    await housing.save();
    return housing;
}

async function getAllHousings() {
    const housings = await Housing.find({}).lean();
    return housings;
}

async function getTopHousings() {
    let sort = {cratedAt: -1};
    const housings = await Housing.find({}).sort(sort).lean();
    return housings;
}


async function getHousingById(id) {
    const housing = await Housing.findById(id).lean();
    return housing;
}

async function editHousing(id, housingData) {
    const housing = await Housing.findById(id).lean();

    housing.name = housingData.name;
    housing.type = housingData.type;
    housing.year = housingData.rooms;
    housing.city = housingData.city;
    housing.homeImage = housingData.homeImage;
    housing.propertyDescription = housingData.propertyDescription;
    housing.availablePieces = housingData.availablePieces;

    return housing.save();
}

async function bookHousing(housingId, userId) {
    const housing = await Housing.findById(housingId);
    const user = await User.findById(userId);

    if (user._id == housing.owner) {
        throw new Error('Cannot book you own hotel!');
    }

    if (housing.availablePieces == 0) {
        throw new Error('No available pieces');
    }
    //user.bookedHotels.push(housing);
    housing.availablePieces -= 1;
    housing.rentedHome.push(user);

    return Promise.all([user.save(), housing.save()]);
}

module.exports = {
    createHousing,
    getAllHousings,
    getTopHousings,
    getHousingById,
    editHousing,
    bookHousing

};
