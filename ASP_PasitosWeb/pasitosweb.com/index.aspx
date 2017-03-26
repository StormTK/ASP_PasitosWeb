<%@ Page Title="" Language="C#" MasterPageFile="~/pasitosweb.com/Plantilla.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ASP_PasitosWeb.pasitosweb.com.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="Anuncio">
            <h2>¡Bienvenido!</h2>
            <p>Mis Pasitos Web te ayudara a llevar el control de los cursos de tus Institución, Facultad o Universidad de una manera rápida y sencilla...</p>
        </div>
        <img src="img/index.png" />
    </section>
    <div class="contenido">
        <h2>¿Que Deseas Hacer?</h2>
        <div class="Butones">
            <a href="manual.aspx">
                <div class="Button">+</div>
            </a>
            <p>Agregar un Curso Manualmente</p>
        </div>
        <div class="Butones">
            <a href="agregar.aspx">
                <div class="Button">↑</div>
            </a>
            <p>Agregar un Curso Masivamente</p>
        </div>
        <div class="Butones">
            <a href="agregar.aspx">
                <div class="Button">↓+</div>
            </a>
            <p>Ver Cursos Registrados</p>
        </div>
    </div>
</asp:Content>
