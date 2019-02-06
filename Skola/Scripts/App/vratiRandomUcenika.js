$(document).ready(function () {

    $.get("/RandomUcenik/GetRandomUcenik", function (data, status) {
        $("#ucenik").html(data);
    });

});