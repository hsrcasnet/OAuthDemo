

$(function () {
    var access_token = null;

    $('#loginButton').click(function () {
        var username = $('#username').val();
        var password = $('#password').val();

        $.ajax({
            url: 'token',
            data: "grant_type=password&username=" + username + "&password=" + password,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            type: 'POST',
            cache: false,
            success: function (result) {
                console.log(result);
                access_token = result.access_token;
                $('<div>').text(JSON.stringify(result)).appendTo($('#output'));
            },
            error: function (request, status, error) {
                console.log(error);
                $('<div>').text(error).appendTo($('#output'));
            }
        });
    });

    $('#callWebApiMethod').click(function () {
        $.ajax({
            url: '/api/hello/sayhello',
            headers: {
                'Authorization': 'Bearer ' + access_token
            },
            success: function (result) {
                $('<div>').text(result).appendTo($('#output'));
            },
            error: function (request, status, error) {
                console.log(error);
                $('<div>').text(error).appendTo($('#output'));
            }
        });
    });

    $('#callGetClaims').click(function () {
        $.ajax({
            url: '/api/hello/getclaims',
            headers: {
                'Authorization': 'Bearer ' + access_token
            },
            success: function (result) {
                $('<div>').text(result).appendTo($('#output'));
            },
            error: function (request, status, error) {
                console.log(error);
                $('<div>').text(error).appendTo($('#output'));
            }
        });
    });

});