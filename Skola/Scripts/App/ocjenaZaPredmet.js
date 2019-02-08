$(document).ready(function () {
    $(".nav-item").click(function () {
        var data = {
            ucenikID: $("#UcenikID").val(),
            predmetID: $(this).attr("data-predmetID")
        };
        $.get("/UcenikPredmet/GetOcjene", data, function (result, status) {
            $("#nav-tabContent").html(result);
        });
    });
    //$(".nav-item").first().trigger("click");
    $(".nav-item").first().trigger("click");
});