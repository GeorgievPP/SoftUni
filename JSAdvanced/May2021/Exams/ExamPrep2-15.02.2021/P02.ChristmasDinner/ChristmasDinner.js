class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    set budget(value) {
        if(value < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this._budget = value;
    }

    get budget() {
        return this._budget;
    }

    shopping([type, price]) {
        if(price > this.budget) {
            throw new Error('Not enough money to buy this product');
        }

        this.budget -= price;
        this.products.push(type);

        return `You have successfully bought ${type}!`;
    }

    recipes({ recipeName, productsList }) {
        if(productsList.some(p => this.products.includes(p) == false)) {
            throw new Error('We do not have this products');
        }

        this.dishes.push({ recipeName, productsList});

        return `${recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        if(this.dishes.some(d => d.recipeName == dish) == false) {
            throw new Error('We do not have this dish');
        } else if (this.guests.hasOwnProperty(name)) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        return Object
            .entries(this.guests)
            .reduce((acc, [guestName, dish]) => acc.concat([`${guestName} will eat ${dish}, which consists of ${this.dishes.find(d => d.recipeName == dish).productsList.join(', ')}`]), [])
            .join('\n');
    }
}

let dinner = new ChristmasDinner(300);