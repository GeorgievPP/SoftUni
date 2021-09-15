const bcrypt = require('bcrypt')

const saltRounds = 10;
const myPlaintextPassword = 'password1';
const someOtherPlaintextPassword = 'password2';

async function gen() {
    const hash = await bcrypt.hash(myPlaintextPassword, saltRounds)
    console.log(hash);
}

function comp(hash) {
    const check1 = await bcrypt.compare(myPlaintextPassword, hash) ;
    console.log('Compare', myPlaintextPassword, '=>', check1);
    const check2 = await bcrypt.compare(someOtherPlaintextPassword, hash) ;
    console.log('Compare', someOtherPlaintextPassword, '=>', check2);
}

gen();
