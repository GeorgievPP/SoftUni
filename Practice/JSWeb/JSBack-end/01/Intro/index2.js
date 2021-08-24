const logger = require('./logger.js');
const _ = require('lodash');
const url = require('url');
const querystring = require('querystring')

let name1 = 'Pesho';

let parsedUrl = url.parse('https://www.npmtrends.com/@angular/core-vs-angular-vs-react-vs-vue?year=2020&quality=great');
let queryParameters = querystring.parse(parsedUrl.query);
console.log(queryParameters);
console.log(queryParameters.year + ' is ' + queryParameters.quality);

logger(name1);

console.log(name1);