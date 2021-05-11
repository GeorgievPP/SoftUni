function solve(area, vol, input) {
    let figures = JSON.parse(input);

    let result = figures.map(function(figure) {
        return {
            area: area.call(figure),
            volume: vol.call(figure)
        };
    });
    return result;
}

function area() {
    return this.x * this.y;
};


function vol() {
    return this.x * this.y * this.z;
};

