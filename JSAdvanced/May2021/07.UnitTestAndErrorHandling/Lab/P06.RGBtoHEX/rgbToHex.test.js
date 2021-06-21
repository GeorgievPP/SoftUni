const { expect } = require('chai');
const rgbToHexColor = require('./rgbToHex');

describe('RGB To HEX', () => {
    it('return black', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });
    it('return white', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    });

    it('return undefined for out of range number1', () => {
        expect(rgbToHexColor(-1, 1, 0)).undefined;
    });
    it('return undefined for out of range number2', () => {
        expect(rgbToHexColor(1, -1, 0)).undefined;
    });
    it('return undefined for out of range number3', () => {
        expect(rgbToHexColor(1, 1, -1)).undefined;
    });

    it('return undefined for out of range positive number1', () => {
        expect(rgbToHexColor(256, 1, 0)).undefined;
    });
    it('return undefined for out of range positive number2', () => {
        expect(rgbToHexColor(1, 300, 0)).undefined;
    });
    it('return undefined for out of range positive number3', () => {
        expect(rgbToHexColor(1, 1, 300)).undefined;
    });

    it('return undefined for invalid input type1', () => {
        expect(rgbToHexColor('1', 1, 0)).undefined;
    });
    it('return undefined for invalid input type2', () => {
        expect(rgbToHexColor(1, [], 0)).undefined;
    });
    it('return undefined for invalid input type3', () => {
        expect(rgbToHexColor(1, 1, {})).undefined;
    });

});