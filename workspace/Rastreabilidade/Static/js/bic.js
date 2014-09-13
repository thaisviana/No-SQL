$(document).ready(function () {


    $('.tema').click(function (event) {
        window.location.href = 'http://localhost:9808/Item?tema_id=' + this.id + '&tema_Nome=' + this.textContent;
    });

    $('#perguntasPA').hide();

    $('#perguntasBP').hide();

    $('#perguntasLA').hide();

    if ($('#titulo').text() != "" && $('#titulo').text() != null) {

        if ($.trim($('#tipoescolhido').text()) == "Lição Aprendida") {
            $('#perguntasLA').show();
        } if ($.trim($('#tipoescolhido').text()) == "Boas Práticas") {
            $('#perguntasBP').show();
        } if ($.trim($('#tipoescolhido').text()) == "Ponto de Atenção") {
            $('#perguntasPA').show();
        }
    }


    $("select").change(function () {
        $("select option:selected").each(function () {
            if ($(this).text() == "Lição Aprendida") {
                $('#perguntasLA').show();
                $('#perguntasPA').hide();
                $('#perguntasBP').hide();
            } if ($(this).text() == "Boas Práticas") {
                $('#perguntasBP').show();
                $('#perguntasLA').hide();
                $('#perguntasPA').hide();
            } if ($(this).text() == "Ponto de Atenção") {
                $('#perguntasPA').show();
                $('#perguntasBP').hide();
                $('#perguntasLA').hide();
            }

        });
    });
});