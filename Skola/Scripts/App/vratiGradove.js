$("#Drzava").change(function () {

    var data = {
        drzavaID: Number($(this).val())
    };

    $.get("/Ucenik/VratiGradove", data, function (result, status) {
        $("#Grad").empty();
        var optionDefault = document.createElement("option");
        optionDefault.text = "Izaberi grad";
        optionDefault.value = -1;
        $("#Grad").append(optionDefault);
        result.forEach(element => {
            var option = document.createElement("option");
            option.value = element.GradID;
            option.text = element.Naziv;
            $("#Grad").append(option);
        });
    });

});