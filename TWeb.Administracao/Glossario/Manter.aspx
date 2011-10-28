<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manter.aspx.cs" Inherits="TWeb.Administracao.Glossario.Manter" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <fieldset>
            <legend>Editar glossário</legend>
            <asp:HiddenField runat="server" ID="IdHiddenField"/>
            <asp:ToolkitScriptManager runat="Server" />
            <asp:TextBox
                    ID="GlossarioTextBox"
                    TextMode="MultiLine"
                    Columns="100"
                    Rows="20"
                    runat="server" />
 
            <asp:HtmlEditorExtender TargetControlID="GlossarioTextBox" runat="server" >
                <Toolbar> 
                    <ajaxToolkit:Undo />
                    <ajaxToolkit:Redo />
                    <ajaxToolkit:Bold />
                    <ajaxToolkit:Italic />
                    <ajaxToolkit:Underline />
                    <ajaxToolkit:StrikeThrough />
                    <ajaxToolkit:Subscript />
                    <ajaxToolkit:Superscript />
                    <ajaxToolkit:JustifyLeft />
                    <ajaxToolkit:JustifyCenter />
                    <ajaxToolkit:JustifyRight />
                    <ajaxToolkit:JustifyFull />
                    <ajaxToolkit:InsertOrderedList />
                    <ajaxToolkit:InsertUnorderedList />
                    <ajaxToolkit:CreateLink />
                    <ajaxToolkit:UnLink />
                    <ajaxToolkit:RemoveFormat />
                    <ajaxToolkit:SelectAll />
                    <ajaxToolkit:UnSelect />
                    <ajaxToolkit:Delete />
                    <ajaxToolkit:Cut />
                    <ajaxToolkit:Copy />
                    <ajaxToolkit:Paste />
                    <ajaxToolkit:BackgroundColorSelector />
                    <ajaxToolkit:ForeColorSelector />
                    <ajaxToolkit:FontNameSelector />
                    <ajaxToolkit:FontSizeSelector />
                </Toolbar>
            </asp:HtmlEditorExtender>

            <div class="buttonrow">
                <asp:Button runat="server" ID="SalvarButton" CausesValidation="true" Text="Salvar" OnClick="SalvarGlossario_Click" />
            </div>
        </fieldset>
    </div>
</asp:Content>
