$("#btnIzracunaj").click(function () {

    var data = {
        vrijednost: $("#txtVrijednost").val(),
        valutaID: Number($("#Valuta").val())
    };

    $.post("/Konverter/GetConvertedValue", data,
        function (result) {
            if (result.Success) {
                $("#prikaz").html("");
                $("#prikaz").append(result.Konvertovano.Vrijednost + " " + result.Konvertovano.NazivValute);
            } else {
                $("#prikaz").html("");
                $("#tijeloModala").html(result.Message);
                $("#modalPrikaz").modal();
            }
            
        });

});