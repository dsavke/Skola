$(".kliknuto").click(function () {
    $("#tijeloIzbrisi").html("Da li zelite izbrsati ovu drzavu?")
    $("#modalDelete").modal();
    $("#btnIzbrisi").attr("data", $(this).attr("data"));
});

$("#btnIzbrisi").click(function () {

    var data = {
        id: $("#btnIzbrisi").attr("data")
    };

    console.log(data);

    var rez = false;

    $.post("/Drzava/Delete", data, function (result) {

        console.log(result);
        rez = result.Success;
        if (result.Success) {

            

            $("#modalDelete").modal("hide");

        }
    });

    
        $.get("/Drzava/List", function (drzaveRez, status) {
            $("#listaDrzava").html(drzaveRez);
        });
  

});