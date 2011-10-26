<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="TWeb.Administracao.Usuarios.Listagem" %>
<%@ Import Namespace="TWeb.Administracao.Util" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView  ID="GridViewListarUsuarios" runat="server" Width="100%"
        OnRowDataBound="GridViewListarUsuarios_RowDataBound" AllowPaging="True" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSourceBuscarUsuarios" CssClass="tabela-gridview">
        <Columns>
            <asp:TemplateField ItemStyle-Width = "80%">
                <HeaderTemplate>Nome do Usuário</HeaderTemplate>
                <ItemTemplate> 
                    <asp:HiddenField ID="Id"  runat="server" Value='<%#Eval("Id")%>'></asp:HiddenField>
                    <%# Eval("Nome") %>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" ItemStyle-Width = "10%" />
            <asp:TemplateField ItemStyle-Width = "10%">
                <HeaderTemplate>Status</HeaderTemplate>
                <ItemTemplate> <%# StatusHelper.TraduzirStatus(Eval("StatusId")) %> </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSourceBuscarUsuarios" runat="server" SelectMethod="BuscarUsuarios" TypeName="TWeb.Administracao.Usuarios.ListagemServico">
    </asp:ObjectDataSource>
</asp:Content>
