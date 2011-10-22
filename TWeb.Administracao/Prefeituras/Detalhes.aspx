﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="TWeb.Administracao.Prefeituras.Detalhes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-container">
    <fieldset>
		<legend>Detalhes da prefeitura</legend>
        <asp:HiddenField runat="server" ID="IdHiddenField" />
        <div>
            <label for="address1">Nome da cidade <em>*</em></label> 
            <asp:TextBox ID="NomeTextBox" size="100" runat="server"  />
        </div>              
		<div>
            <label for="address2">Aderência (%)</label> 
            <asp:TextBox ID="AderenciaTextBox" runat="server" size="1"  />
        </div>
        <div>
            <label for="ordem">Ordem</label> 
            <asp:TextBox ID="OrdemTextBox" runat="server" size="1"  />
        </div>
		<div>
			<label for="type">Status <em>*</em></label>
            <asp:DropDownList ID="StatusDropDownList" runat="server">
                <asp:ListItem Value="1">Ativo</asp:ListItem>
                <asp:ListItem Value="2">Inativo</asp:ListItem>
                <asp:ListItem Value="3">Indeterninado</asp:ListItem>
            </asp:DropDownList>
		</div>
        <div class="controlset">
            <span class="label">Documentos <em>*</em></span>
            <asp:CheckBoxList ID="DocumentosCheckBoxList" RepeatDirection="Horizontal"  runat="server">
                <asp:ListItem Value="1">LDO</asp:ListItem>
                <asp:ListItem Value="1">BF</asp:ListItem>
                <asp:ListItem Value="1">BP</asp:ListItem>
                <asp:ListItem Value="1">RREO</asp:ListItem>
                <asp:ListItem Value="1">PPA</asp:ListItem>
                <asp:ListItem Value="1">BO</asp:ListItem>
                <asp:ListItem Value="1">LC</asp:ListItem>
                <asp:ListItem Value="1">Painel Financeiro</asp:ListItem>
                <asp:ListItem Value="1">Parecer TCE</asp:ListItem>
            </asp:CheckBoxList>
		</div>	
        <div class="buttonrow">
            <asp:Button runat="server"  CausesValidation="true"  CommandName="Update" Text="Atualizar" onclick="AtualizarPrefeitura_Click" />
            <input type="button" value="Voltar" onclick="window.location.href='listagem.aspx'" />
	    </div>
	</fieldset>
</div>
       
</asp:Content>
