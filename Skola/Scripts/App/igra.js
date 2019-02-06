/*var btn = $(".number");

btn.forEach(ele => {
    console.log(ele);
});*/

/*$('.number').each(function () {
    //if statement here 
    // use $(this) to reference the current div in the loop
    //you can try something like...


    console.log($(this).children(".vrijednost").val());
    

});*/

$(".number").click(function (ele) {
    var pogadjanBroj = $(this).children().html();
    var nasumicanBroj = $("#vrijednost").html();
    //console.log($("#vrijednost").html());

    var trenutniBrojPokusaja = $("#txtPokusaji").html();
    trenutniBrojPokusaja++;
    $("#txtPokusaji").html(`${trenutniBrojPokusaja}`);

    if (nasumicanBroj < pogadjanBroj) {
        $("#txtPoruka").html(`Trazeni broj je manji od ${pogadjanBroj}!`)
        $(this).addClass("nova-boja");
    } else if (nasumicanBroj > pogadjanBroj) {
        $("#txtPoruka").html(`Trazeni broj je veci od ${pogadjanBroj}!`);
        $(this).addClass("nova-boja");
    } else {
        $("#txtPoruka").html("Pogodili ste broj!");
        $(this).addClass("pobjeda");
    }
   
});