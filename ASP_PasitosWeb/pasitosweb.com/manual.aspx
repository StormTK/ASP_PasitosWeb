<%@ Page Title="" Language="C#" MasterPageFile="~/pasitosweb.com/Plantilla.Master" AutoEventWireup="true" CodeBehind="manual.aspx.cs" Inherits="ASP_PasitosWeb.pasitosweb.com.manual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/manual.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formulario">
        <h2>Ingrese el Curso</h2>
        <p>Ingrese el Codigo del Curso</p>
        <asp:TextBox runat="server" ID="txt_codigo" CssClass="txt_formulario"></asp:TextBox>
        <p>Ingrese el Nombre del Curso</p>
        <asp:TextBox runat="server" ID="txt_nombre" CssClass="txt_formulario"></asp:TextBox>
        <p>Ingrese el Prerequisito del Curso</p>
        <asp:TextBox runat="server" ID="txt_requisito1" CssClass="txt_formulario"></asp:TextBox>
        <asp:Button ID="btn_Enviar" Class="Button" runat="server" Text="Registrar" OnClick="btn_Registrar_Click" />
    </div>
</asp:Content>
