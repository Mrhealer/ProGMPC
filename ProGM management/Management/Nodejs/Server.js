
var app = require('http').createServer();
var io = require('socket.io').listen(app);

app.listen(8000, '127.0.0.1', function () {
    console.log('listening on 127.0.0.1:8000');
});


io.on('connection', function (socket) {
    console.log('a user connected ID:' + socket.id);
    socket.on('disconnect', function () {
        console.log('user disconnected');
    });

    socket.on('VeryToken', function (token) {
        console.log('Token: ' + token);
    });
    socket.on('SEND_DATA', function (data) {
        console.log('Send data: ' + data);
    });
    socket.on('SEND_MESSAGE', function (data) {
        console.log('Send message: ' + data);
    });
});
