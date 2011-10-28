<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manter.aspx.cs" Inherits="TWeb.Administracao.Glossario.Manter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <fieldset>
            <legend>Editar glossário</legend>
            <asp:HiddenField runat="server" ID="IdHiddenField"/>
            <asp:TextBox ID="GlossarioTextBox" runat="server"></asp:TextBox>
            <div class="buttonrow">
                <asp:Button runat="server" ID="SalvarButton" CausesValidation="true" Text="Salvar" OnClick="SalvarGlossario_Click" />
            </div>
        </fieldset>
    </div>
</asp:Content>
