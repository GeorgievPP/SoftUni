const http = require('http');
const url = require('url');
const querystring = require('querystring');
const fs = require('fs');

const port = 3000;

function requestHandler(req, res) {
    let reqUrl = url.parse(req.url);
    let params = querystring.parse(reqUrl.query);
    console.log(params);
    console.log(reqUrl.pathname);

    switch (reqUrl.pathname) {
        case '/cats':
            res.writeHead(200, {
                'Content-Type': 'text/html'
            });

            fs.readFile('./views/cats.html', (err, data) => {
                if (err) {
                    console.log('some error');
                    return;
                }

                res.write(data);
                res.end();
            });
            break;
        case '/dogs':
            res.writeHead(200, {
                'COntent-Type': 'text/plain'
            });

            res.write('Hello Dogs!');
            res.end();
            break;
        default:
            res.writeHead(404, {
                'COntent-Type': 'text/plain'
            });
            res.end();
            break;
    }

}

const app = http.createServer(requestHandler);

app.listen(port, () => console.log(`Server is listening at port ${port}...`));