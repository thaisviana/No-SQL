
$(function () {
    $("#oldID").val($("#Nome").val());
    var tables = $('#TabelasComVirgulas').val();

    $('#count').ready(function () {
        var table_split = tables.split(",");
        if ($('.h2').attr("id") == '') {
            $('#count').html(table_split.length - 1);
        } else {
            $('#count').html(table_split.length);
        }
    });

    $('#save').click(function (event) {
        $('#TabelasComVirgulas').val(tables);
    });

    //Colocando links nas tabelas
    $('li').each(function (index) {
        var table_name = $.trim($(this).text());
        $(".a-" + table_name).attr("href", "/tabela/" + generateSlug(table_name));
    });

    $('#icon-plus').click(function (event) {
        var table_split = tables.split(",");
        var nome = $('#table').val();
        if ($('#table').val() == '') return;

        //Verificando se a tabela já existe no modulos
        for (i = 0; i < tables.split(",").length; i++) {
            if (table_split[i] == $('#table').val()) {
                $('#' + nome).css('font-weight', 'bolder');
                $('#' + nome).hide().fadeIn(1000);
                setTimeout(function () {
                    $('#' + nome).css('font-weight', 'normal');
                }, 2000);
                $('#table').val('');
                return;
            }
        }
        $('#' + nome).hide().fadeIn(2000);
        var data = { 'tableName': $('#table').val() };
        var template = $('#list-item-table').html();
        var html = Mustache.to_html(template, data);
        $('#list_table').append(html);
        tables = tables + "," + $('#table').val();
        table_split = tables.split(",");
        if ($('.h2').attr("id") == '') {
            $('#count').html(table_split.length - 1);
        } else {
            $('#count').html(table_split.length);
        }
        //Link da tabela nova
        $("#a-" + nome).attr("href", window.location.protocol + "//" + window.location.host + "/tabela/" + nome);
        $('#table').val('');
        $('.icon-remove').click(function (event) {
            tables = removeTables(tables, this);
        });
    });
    $('.icon-remove').click(function (event) {
        tables = removeTables(tables, this);
    });
});
function removeTables(tables, removed) {
    var del = $(removed).parent().attr("id").split("-");
    var table_split = tables.split(",");
    for (i = 0; i < tables.split(",").length; i++) {
        if (table_split[i] == del[2]) {
            table_split.splice(i, 1);
        }
    }
    if ($('.h2').attr("id") == '') {
        $('#count').html(table_split.length - 1);
    } else {
        $('#count').html(table_split.length);
    }
    tables = table_split.join(",");
    var li = $(removed).parents('li.list-item');
    li.remove();
    return tables;
}