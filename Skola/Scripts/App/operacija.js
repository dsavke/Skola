$("#btnIzracunaj").click((event) => {

    event.preventDefault();

    var data = {
        operacija: $("#Operacija:checked").val(),
        vrijednostPrvogPolja: $("#vrijednost1").val(),
        vrijednostDrugogPolja: $("#vrijednost2").val()
    };

    $("#rezultat").val(operacija(data));

    function operacija(data) {

        switch (data.operacija) {
            case "+":
                return Number(data.vrijednostPrvogPolja) + Number(data.vrijednostDrugogPolja);
            case "-":
                return Number(data.vrijednostPrvogPolja) - Number(data.vrijednostDrugogPolja);
            case "*":
                return Number(data.vrijednostPrvogPolja) * Number(data.vrijednostDrugogPolja);
            case "/":
                return Number(data.vrijednostPrvogPolja) / Number(data.vrijednostDrugogPolja);
            default: return 0;
        }
    };

});