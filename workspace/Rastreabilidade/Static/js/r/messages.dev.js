$(function () {
    $("#messages button").click(function () {
        $('#messages:visible').fadeOut("slow");
    });
});

//variável global com as classes de alert
var _messageClasses = ["alert-success", "alert-info", "", "alert-error"];

function renderMessage(jsonResponse) {
    $("#messages").removeClass().addClass("alert " + _messageClasses[jsonResponse.Status]);
    $("#messages strong").text(jsonResponse.Title);
    $("#messages span").text(jsonResponse.Message);

    // verificando se a div é visível
    $('#messages:hidden').fadeIn("slow");
}