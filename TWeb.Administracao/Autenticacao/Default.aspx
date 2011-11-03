<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TWeb.Administracao.Autenticacao.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div  class="accountInfo">
        <asp:Panel ID="ErroAutenticacaoPanel" runat="server" Visible="false" CssClass="menssagem-erro">
            <p>Usuário ou senha inválidos!</p>
        </asp:Panel>
        <fieldset class="login">
            <legend>Autenticar usuário</legend>
            <p>
                <label>Usuário:</label>
                <asp:TextBox ID="UsuarioTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                <label>Senha:</label>
                <asp:TextBox ID="SenhaTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <p>
                <asp:Button ID="EntrarButton" runat="server" Text="Entrar" OnClick="AutenticarUsuario_Click" />
            </p>
        </fieldset>
       
    </div>
</asp:Content>
