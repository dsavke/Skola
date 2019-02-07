$(document).ready(function () {
    $(".kliknuto").click(function () {
        $("#tijeloIzbrisi").html("Da li zelite izbrsati ovu drzavu?")
        $("#modalDelete").modal();
        $("#btnIzbrisi").attr("data", $(this).attr("data"));

        console.log("Brisanje drzave izabrao drzavu");

    });
});

$(document).ready(function () {
    $("#btnIzbrisi").click(function (event) {

        event.preventDefault();

    var data = {
        id: $("#btnIzbrisi").attr("data")
    };

        $.post("/Drzava/Delete", data, function (result) {
            console.log(data);
        if (result.Success) {


            console.log("obrisao");
            $("#modalDelete").modal("hide");

            $.get("/Drzava/List", function (drzave, status) {
                $("#listaDrzava").html(drzave);
            });


        } else {
            console.log("nije obrisalo");
        }
        });
  
    });
});