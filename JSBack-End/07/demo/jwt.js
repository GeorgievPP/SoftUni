const jwt = require('jsonwebtoken');

const payload = { message: 'HI!'};
const secret = 'my-secret-key';

const token = jwt.sign(payload, secret, { expiresIn: '2d' });

const myToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJtZXNzYWdlIjoiSEkhIiwiaWF0IjoxNjMxMDk2ODgyLCJleHAiOjE2MzEyNjk2ODJ9.VQD4jNMnSSoR6RTjvNzuYuKc_DwLWHBi9nYpL1_EEYA';

console.log(jwt.decode(myToken));
console.log(jwt.verify(myToken, secret));
