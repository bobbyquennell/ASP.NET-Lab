$(function () {
    var getPatients = function () {
        var url = "http://localhost:5983/api/patients/";
        $.ajax(url, {
            type: "GET",
            headers: getHeaders()
        }).always(showResponse);
        return false;
    };
    var getHeaders = function () {
        if (myAccessToken) {
            return { "Authorization": "Bearer " + myAccessToken };
        }
    };
    var showResponse = function (object) {
        $("#output").text(JSON.stringify(object, null, 4));

    }
    var register = function () {
        var url = "/api/account/register";
        var data = $("#UserData").serialize();
        $.post(url, data).always(showResponse);
        return false;
    }
    var myAccessToken = "";
    var saveToken = function (data) {
        myAccessToken = data.access_token;
    };
    var login = function () {
        var url = "/Token";
        var data = $("#UserLogin").serialize();
        data += "&grant_type=password";
        $.post(url, data).success(saveToken).always(showResponse);
        return false;
    }


    $("#login").click(login);
    $("#register").click(register);
    $("#getPatients").click(getPatients);
});