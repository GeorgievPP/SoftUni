function printDeckOfCards(cards) {
    function createCard (face, suit){
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A' ];
        const suitToString = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
    
        };
    
        if(validFaces.includes(face) == false) {
            throw new Error('Invalid face');
        } else if(Object.keys(suitToString).includes(suit) == false) {
            console.log(Object.keys(suitToString));
            throw new Error('Invalid suit');
        }
    
        return {
            face,
            suit,
            toString() {
                return `${face}${suitToString[suit]}`;
            }
        }
    }
    
    
    const deck = [];
    for (const card of cards) {
        try {
            const arr = [...card];
            const face = arr.length == 3 ? arr.slice(0, 2).join('') : arr.shift();
            const suit = arr.pop();
            deck.push(createCard(face, suit));
        } catch (ex) {
            console.log(`Invalid card: ${card}`);
        }
    }

    console.log(deck.map((card) => card.toString()).join(' '));


  }
//50/100
  printDeckOfCards(['5S', '3D', 'QD', '1C']);
  