$(document).ready(function () {

    $.get("/RandomUcenik/GetRandomUcenik", function (data, status) {
        $("#ucenik").html(data);
    });

});

$("#btnPrikaziRandomUcenika").click(function () {
    $.get("/RandomUcenik/GetRandomUcenik", function (data, status) {
        $("#tijeloModala").html(data);
        $("#modalPrikaz").modal();
    });
});