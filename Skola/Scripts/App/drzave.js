$(document).ready(function () {
    
    $.get("/Drzava/List", function (data, status) {
        $("#listaDrzava").html(data);
    });

}); 

$("#btnNovaDrzava").click(function () {
    $("#modalPrikaz").modal();
});

$("#btnSacuvaj").click(function () {

    var data = {
        naziv: $("#txtNaziv").val()
    };

    $.post("/Drzava/Create", data, function (result, status) {

        if (result.Success) {

            $.get("/Drzava/List", function (drzave) {
                $("#listaDrzava").html(drzave);
            });

            $("#txtMessage").html("");
            $("#txtNaziv").val("");
            $("#modalPrikaz").modal('hide');

        } else {

            $("#txtMessage").html(result.Message);
            $("#txtMessage").attr("display", "block");

        }

    });

});

$("#btnX").click(function () {
    $("#txtMessage").html("");
    $("#txtNaziv").val("");
});

$("#btnClose").click(function () {
    $("#txtMessage").html("");
    $("#txtNaziv").val("");
});