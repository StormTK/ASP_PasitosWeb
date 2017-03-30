<%@ Page Title="" Language="C#" MasterPageFile="~/pasitosweb.com/Plantilla.Master" AutoEventWireup="true" CodeBehind="cargarcurso.aspx.cs" Inherits="ASP_PasitosWeb.pasitosweb.com.cargarcurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/cargarcurso.css" rel="stylesheet" />

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
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> No ha seleccionado ningun archivo</p></div>");
                            break;
                        case 2:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> Solo se permiten archivos con extensión \".csv\" </p></div>");
                            break;
                        case 3:
                            Response.Write("<div class=\"exito\" > <p class=\"icon-checkmark\"> </p><p class=\"mensaje\"> Se han Registrado con Éxito los Cursos</p></div>");
                            break;
                        case 4:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El Archivo no se pudo subir! Intentelo de Nuevo</p></div>");
                            break;
                        case 5:
                            Response.Write("<div class=\"error\" > <p class=\"icon-cross\"> </p><p class=\"mensaje\"> ERROR <br /> El Archivo contiene errores</p></div>");
                            break;
                    
                    }
                }
            %>
            <h2>Seleccione el Archivo que desea subir:</h2>
            <asp:FileUpload ID="archivo" runat="server" />
            <asp:Button ID="Enviar" CssClass="Button" runat="server" Text="Enviar" OnClick="Enviar_Click" />
        </div>
    </div>
</asp:Content>
