<%@ Page Title="" Language="C#" MasterPageFile="~/pasitosweb.com/Plantilla.Master" AutoEventWireup="true" CodeBehind="crearcurso.aspx.cs" Inherits="ASP_PasitosWeb.pasitosweb.com.manual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/agregarcurso.css" rel="stylesheet" />
    <script src="jsp/SoloNumeros.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="formulario">
            <%

                if (Request.QueryString.Get("msg") != null)
                {
                    int msg = Int32.Parse(Request.QueryString.Get("msg"));
                    switch (msg)
                    {
                        case 1:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El Codigo/Nombre del Curso no pueden ser campos vacios</p></div>");
                            break;
                        case 2:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El Curso ya esta Registrado en la Aplicación</p></div>");
                            break;
                        case 3:
                            Response.Write("<div class=\"exito\" > <p class=\"icon-checkmark\"> </p><p class=\"mensaje\"> Se ha Registrado el curso con Exito</p></div>");
                            break;
                        case 4:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El Curso no se pudo registrar en la Aplicación</p></div>");
                            break;
                        case 5:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El PreRequisito no esta registrado en la Aplicación</p></div>");
                            break;
                        case 6:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El PreRequisito no se pudo regristrar en la Aplicación</p></div>");
                            break;
                        case 7:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El PreRequisito ya esta regristrado en la Aplicación</p></div>");
                            break;
                        case 8:
                            Response.Write("<div class=\"exito\" > <p class=\"icon-checkmark\"> </p><p class=\"mensaje\"> Se ha Registrado el nuevo PreRequisito al Curso con Exito</p></div>");
                            break;
                    }
                }
            %>
            <h2>Registro de Curso</h2>
            <p class="consejo">(*) Son Campos Obligatorios</p>

            <p>Ingrese el nombre del Curso: <span class="consejo">(*)</span> </p>
            <asp:TextBox runat="server" ID="txt_nombre" MaxLength="60" CssClass="txt_formulario"></asp:TextBox>

            <p>Ingrese la Cantidad de Creditos del Curso: <span class="consejo">(*)</span></p>
            <asp:TextBox runat="server" ID="txt_credito" MaxLength="3" CssClass="txt_formulario" onkeydown="return numeros(event);"></asp:TextBox>

            <p>Ingrese el Nombre del Prerequisito del Curso:</p>
            <asp:TextBox runat="server" ID="txt_requisito" CssClass="txt_formulario"></asp:TextBox>

            <asp:Button ID="btn_Enviar" Class="Button" runat="server" Text="Registrar" OnClick="btn_Registrar_Click" />
        </div>
    </div>
</asp:Content>
