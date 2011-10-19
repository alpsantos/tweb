<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prefeituras.aspx.cs" Inherits="TWeb.Administracao.Prefeituras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
            <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
            <asp:BoundField DataField="Aderencia" HeaderText="Aderencia" SortExpression="Aderencia" />
            <asp:BoundField DataField="Ordem" HeaderText="Ordem" SortExpression="Ordem" />
            <asp:BoundField DataField="StatusId" HeaderText="StatusId" SortExpression="StatusId" />
            <asp:BoundField DataField="DocumentosId" HeaderText="DocumentosId" SortExpression="DocumentosId" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="BuscarPrefeiturasPaginaInicial" TypeName="TWeb.Servico.PrefeituraServico">
    </asp:ObjectDataSource>

    
</asp:Content>
