<%@ Page Title="" Language="C#" MasterPageFile="~/pasitosweb.com/Plantilla.Master" AutoEventWireup="true" CodeBehind="cargarcurso.aspx.cs" Inherits="ASP_PasitosWeb.pasitosweb.com.cargarcurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/cargarcurso.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Seleccione el Archivo que desea subir:</h2>
        <asp:FileUpload ID="archivo" runat="server"/>
        <asp:Button ID="Enviar" runat="server" text="Enviar"/>
    </div>
    
</asp:Content>
