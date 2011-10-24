 function buscarPrefeitura(paginaIndice) {
        $("#div-fixo-loading").fadeIn();
        $.post("Index/PaginacaoPrefeitura", {paginacao: paginaIndice}, function (prefeituraJson, status) {carregarTabelaPrefeitura(prefeituraJson, status,paginaIndice); });
    }

    function carregarTabelaPrefeitura(prefeituraJson, status, paginaIndice) {
        var prefeituraTemplate = $("#tmplPrefeituras").template();
        $("#ul-prefeitura").find('li').remove();
        $.tmpl(prefeituraTemplate, prefeituraJson).appendTo('#ul-prefeitura');
        ConfiguraProgressBar();
        $("#div-paginacao").pager({ pagenumber: (paginaIndice == undefined) ? 1 : paginaIndice, pagecount: 129, buttonClickCallback: PageClick });
        $("#div-fixo-loading").fadeOut(300);
    }

    var PageClick = function (indicePagina) {
        buscarPrefeitura(indicePagina);
    }



    /*
    
    <script id="tmplPrefeituras" type="text/x-jquery-tmpl">
        <li>
            <img alt="${Nome}" title="${Nome}" width="115" height="115" src="@Url.Content("~/content/images/Americana-SP.jpg")"/>
            <label class="label-nome-prefeitura">${Nome}</label>
            <label class="label-relatorios-criados">Relatórios Criados:</label>
            <label class="label-links-criados">
                <a href="#">PPA</a>, <a href="#">LDO</a>, <a href="#">BO</a>, <a href="#">LC</a>, <a href="#">Painel Financeiro</a>
            </label>
            <label class="label-relatorios-pendentes">Relatórios Pendentes:</label>
            <label class="label-links-pendentes">
                LOA, BF, BP, RGF, RREO, Relatório e Parecer do TCE
            </label>
             {{if Aderencia < 20}}
              <div class="progressbar progs-bar-pendente" valueprogress="${Aderencia}"></div>
             {{/if}}
             {{if Aderencia >= 20 && Aderencia <85}}
              <div class="progressbar progs-bar-parcialmente" valueprogress="${Aderencia}"></div>
             {{/if}}
             {{if Aderencia >= 85}}
             <div class="progressbar progs-bar-regulamentado" valueprogress="${Aderencia}"></div>
             {{/if}}
            <label class="label-porcentagem-regulamentado">${Aderencia}% Regulamentado</label>
        </li>
    </script>
    
    
    */