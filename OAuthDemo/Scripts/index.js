

$(function () {
    var token = null;

    $('#loginButton').click(function () {
        var username = $('#username').val();
        var password = $('#password').val();
        console.log(username);
        console.log(password);

        // todo oauth login
        $.ajax({
            url: 'token',
            data: "grant_type=password&username=" + user.userName + "&password=" + user.password,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            type: 'POST',
            success: function(result) {
                token = result;
            },
            error: function(request, status, error) {
                console.log(request);
                console.log(status);
                console.log(error);
            }
        });
    });

    $('#callWebApiMethod').click(function() {
        $.ajax({
            url: '/api/hello/sayhello',
            headers: {
                'Authorization' : 'Bearer lkadsfdsfalkjfdafdaljfdsalkjfdsa'
            },
            success: function(result) {
                $('<div>').text(result).appendTo($('#output'));
            }
        });
    });

});