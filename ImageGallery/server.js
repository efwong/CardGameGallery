let path = require('path');
let express = require('express');
let webpack = require('webpack');

let app = express();

let PORT = process.env.PORT || 3020;

// app.get('*', function(req, res) {
//   res.sendFile(path.join(__dirname, 'index.html'));
// });

app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname + '/index.html'));
});


app.use('/public', express.static('public'));

app.listen(PORT, 'localhost', function(err) {
  if (err) {
    console.log(err);
    return;
  }
  console.log(`✅  Listening at http://localhost:${PORT}`);
});
