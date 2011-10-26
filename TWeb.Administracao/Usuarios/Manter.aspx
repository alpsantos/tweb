<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manter.aspx.cs" Inherits="TWeb.Administracao.Usuarios.Manter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="form-container">
    <fieldset>
		<legend>Detalhes da usuário</legend>

        <asp:Repeater ID="ErrosRepeater" runat="server">
            <ItemTemplate>
                <div class="menssagem-erro">
                    <p><%# Container.DataItem %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Panel ID="SucessoPanel" runat="server" Visible="false" CssClass="menssagem-sucesso">
            <p>Os dados foram salvos com sucesso!</p>
        </asp:Panel>

        <asp:HiddenField runat="server" ID="IdHiddenField"/>
        <div>
            <label>Nome<em>*</em></label> 
            <asp:TextBox ID="NomeTextBox" size="50" runat="server"  />
        </div>
        <div>
            <label>Login<em>*</em></label> 
            <asp:TextBox ID="LoginTextBox" size="50" runat="server"  />
        </div>               
		<div>
            <label for="address2">Email<em>*</em></label> 
            <asp:TextBox ID="EmailTextBox" runat="server" size="50"  />
        </div>
        <div>
            <label for="ordem">Senha<em>*</em></label> 
            <asp:TextBox ID="SenhaTextBox" runat="server" size="50"  />
        </div>
		<div>
			<label for="type">Status</label>
            <asp:DropDownList ID="StatusDropDownList" runat="server">
                <asp:ListItem Value="1">Ativo</asp:ListItem>
                <asp:ListItem Value="2">Inativo</asp:ListItem>
                <asp:ListItem Value="3">Indeterninado</asp:ListItem>
            </asp:DropDownList>
		</div>
        <div class="buttonrow">
            <asp:Button runat="server" ID="SalvarButton"  CausesValidation="true" Text="Salvar" onclick="SalvarUsuario_Click" />
            <input type="button" value="Voltar" onclick="window.location.href='listagem.aspx'" />
	    </div>
	</fieldset>
</div>
</asp:Content>
