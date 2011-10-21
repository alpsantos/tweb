<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="TWeb.Administracao.Prefeituras.Listagem" %>
<%@ Import Namespace="TWeb.Administracao.Servicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView  ID="GridViewListarPreituras" runat="server" 
        Width="100%"
        OnRowDataBound="GridViewListarPreituras_RowDataBound" AllowPaging="True" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSourceBuscarPrefeituras" CssClass="tabela-gridview">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"/>
            <asp:TemplateField ItemStyle-Width = "80%">
                <HeaderTemplate>Nome da Prefeitura</HeaderTemplate>
                <ItemTemplate> 
                    <%# Eval("Nome") %>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Aderencia" HeaderText="Aderência" SortExpression="Aderencia" ItemStyle-Width = "10%" />
            <asp:TemplateField ItemStyle-Width = "10%">
                <HeaderTemplate>Status</HeaderTemplate>
                <ItemTemplate> <%# Helper.ConverterStatus(Eval("StatusId")) %> </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSourceBuscarPrefeituras" runat="server" SelectMethod="BuscarPrefeiturasPaginaInicial" TypeName="TWeb.Servico.PrefeituraServico">
    </asp:ObjectDataSource>

    
</asp:Content>
