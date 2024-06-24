function ocultarVisualizacaoColuna(e) {
    e.preventDefault();

    if ($(".reexibir-vis:hidden").length == 1) return;

    var colunaId = $(this).attr('data-column');
    var coluna = tabela.column(colunaId);

    $("#rv-" + colunaId).show();
    $("p.reexibir").show();

    coluna.visible(false);
}

function reexibirVisualizacaoColuna(e) {
    e.preventDefault();

    var coluna = tabela.column($(this).attr('data-column'));
    $(this).hide();

    if ($(".reexibir-vis:visible").length == 0) $("p.reexibir").hide();

    coluna.visible(true);
}

function reexibirTodasColunas(e) {
    e.preventDefault();

    tabela.columns().visible(true);
    $("p.reexibir").hide(); //Definir hidden para o paragrafo pai
    $(".reexibir-vis").hide(); //Definir hidden para todos os reexibir
}