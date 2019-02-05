$("#btnKlik").click(function (event) {

    event.preventDefault();

    var data = {
        pretraga: $("#txtPrikaz").val(),
        odjeljenje: $("#odjeljenjeID").val(),
        pol: $("#Pol:checked").val() == undefined ? "" : $("#Pol:checked").val()
    };

    $.get("/Statistika/Pretraga", data, function (result, status) {
        $("#prikaz").html(result);
    });

});