
$(function () {
    var tabelas = "";
    $('#salvar').click(function (event) {
        alert(tabelas);
        $(".form").submit("HandleForm", "Rastreabilidade");
    });
    $('#icon-plus').click(function (event) {
        $('#listaTabelas').append('<div>' + $('#tabela').val() + '</div>');
        $('#tabelass').val($('#tabelass').val() + "," + $('#tabela').val());
        $('#tabela').val('');
    });
})