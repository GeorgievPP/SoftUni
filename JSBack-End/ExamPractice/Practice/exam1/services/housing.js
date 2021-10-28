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

module.exports = {
    createHousing,
    getAllHousings,
    getHousingById,
    editHousing,

};
