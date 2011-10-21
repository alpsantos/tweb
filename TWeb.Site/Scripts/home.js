

    function ConfiguraProgressBar() {
        $(".progressbar").each(function () {
            var valueProgressBar = $(this).attr('valueprogress');
            $(this).progressbar();
            $(this).progressbar("option", "value", parseFloat(valueProgressBar));
        });
        $('#div-resultado ul li:last').css('border-bottom', 'none');
    }

    function buscarPrefeitura(paginaIndice) {
        $("#div-fixo-loading").css("visibility","visible");
        $.post("Index/PaginacaoPrefeitura", {paginacao: paginaIndice}, function (prefeituraJson, status) {carregarTabelaPrefeitura(prefeituraJson, status,paginaIndice); });
    }

    function carregarTabelaPrefeitura(prefeituraJson, status, paginaIndice) {
        var prefeituraTemplate = $("#tmplPrefeituras").template();
        $("#ul-prefeitura").find('li').remove();
        $.tmpl(prefeituraTemplate, prefeituraJson).appendTo('#ul-prefeitura');
        ConfiguraProgressBar();
        $("#div-paginacao").pager({ pagenumber: (paginaIndice == undefined) ? 1 : paginaIndice, pagecount: 129, buttonClickCallback: PageClick });	 
        $("#div-fixo-loading").css("visibility","hidden");
    }



    var PageClick = function (indicePagina) {
        buscarPrefeitura(indicePagina);
    }

