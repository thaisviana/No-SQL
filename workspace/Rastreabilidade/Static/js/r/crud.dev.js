
$(function () {

    /* ========================================
    * Preenchendo campo de URL automáticamente
    *  ========================================*/

    //setando url básica e preenchendo campo com ela
    var urlSections = window.location.pathname.split('/');
    var controller = urlSections[1];
    var action = 'save' // por padrão queremos salvar a entidade
    var urlBase = window.location.protocol + "//" + window.location.host;

    var nameInput = $("form#crud #Nome");
    var urlInput = $("form#crud #url");


    // função responsável por preencher o campo de url
    function fillUrl(id) {
        urlInput.val(urlBase + "/" + controller);

        var slash = (!id) ? "" : "/";
        urlInput.val(urlInput.val() + slash + generateSlug(id));
    }

    //chamando valor padrão na abertura da página
    fillUrl(urlSections.length > 2 ?
            window.location.pathname.split('/')[2] : "");

    //adicionando evento que preenche a url automaticamente enquanto vc escreve o nome
    nameInput.keyup(function () {
        fillUrl(this.value);
    });
    if (nameInput.val() == '') {
        $('#delete').attr("disabled", "disabled");
    }

    //tornando o input de url inativo
    urlInput.attr("disabled", true);

    /* ========================================
    * Lidando com os botões e fazendo requests
    *  ========================================*/
    $("form#crud").submit(function (e) {

        e.preventDefault(); // não deixando que o formulário se submeta
        var url = urlInput.val().replace(urlBase, '');

        $.ajax({
            type: 'POST',
            url: url + "/" + action,
            data: $(this).serialize(),
            success: function (res) {
                renderMessage(res); //mostrando mensagem de sucesso
                setTimeout(function () {
                    document.location.href = redirect(action); // redireciona pra url nova
                }, 2000);
            },
            dataType: "json"
        });
    });

    // ao clicar o botão deve submeter o formulário com a ação 'save'
    $("form#crud input#save").click(function (e) {
        if (validate()) {
            action = 'save';
            $("form#crud").submit();
        }
    });

    // ao clicar o botão deve submeter o formulário com a ação 'delete'
    $("form#crud input#delete").click(function (e) {
        if (validate()) {
            bootbox.confirm("Deseja realmente deletar?", function (result) {
                if (result) {
                    action = 'delete';
                    $("form#crud").submit();
                }
            });
        }
        return;
    });

});
function redirect(action) {
    var newUrl;
    if (action == "save") {
        newUrl = $('#url').val();

    } else {
        newUrl = window.location.protocol + "//" + window.location.host;
    }
    return newUrl;
}

function validate() {
    if ($('#Nome').val() == '') {
        $('#messages').html("Campo nome não pode ser vazio, por favor insira um nome");
        $('#messages').animate({ height: "toggle", opacity: "toggle" }, "slow");
        $('#messages').delay(1000).animate({ height: "toggle", opacity: "toggle" }, "slow");
        return false;
    }
    return true;
}