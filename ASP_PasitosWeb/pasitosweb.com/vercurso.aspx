<%@ Page Title="" Language="C#" MasterPageFile="~/pasitosweb.com/plantilla.Master" AutoEventWireup="true" CodeBehind="vercurso.aspx.cs" Inherits="ASP_PasitosWeb.pasitosweb.com.vercurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Response.Write(MostrarCurso());
    %>
</asp:Content>
