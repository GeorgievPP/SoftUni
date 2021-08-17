const http = require('http');
const port = 3000;

function requestHandler(req, res) {
    res.write('Hello World!');
    res.end();
}

const app = http.createServer(requestHandler);

app.listen(port, () => console.log(`Server is listening at port ${port}...`));