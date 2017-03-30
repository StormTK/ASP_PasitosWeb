using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_PasitosWeb.pasitosweb.com
{
    public partial class cargarcurso : System.Web.UI.Page
    {
        codigo.curso Agregar = new codigo.curso();
        String Carpeta;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Enviar_Click(object sender, EventArgs e)
        {
            Carpeta = Path.Combine(Request.PhysicalApplicationPath, "pasitosweb.com\\temp");
            if (archivo.PostedFile.FileName == "")//Si el Arhcivo esta vacio
            {
                Response.Redirect("cargarcurso.aspx?msg=1", false);
            }
            else
            {
                String Extension = Path.GetExtension(archivo.PostedFile.FileName);
                switch (Extension.ToLower())
                {
                    case ".csv":
                        break;
                    default:
                        Response.Redirect("cargarcurso.aspx?msg=2", false);
                        return;
                }
                try
                {
                    String SubirArchivo = Path.GetFileName(archivo.PostedFile.FileName);
                    String ArchivoFinal = Path.Combine(Carpeta, SubirArchivo);
                    archivo.PostedFile.SaveAs(ArchivoFinal);
                    leerArchivo(ArchivoFinal);
                }
                catch
                {
                    Response.Redirect("cargarcurso.aspx?msg=4", false);
                }
            }

        }
        public void leerArchivo(String Ruta)
        {
            int contador = 0;
            String Linea = "";
            System.IO.StreamReader file = new System.IO.StreamReader(@Ruta);

            while ((Linea = file.ReadLine()) != null)
            {
                if (contador > 0)
                {
                    string[] datos = Linea.Split(',');
                    int credito = Int32.Parse(datos[1]);
                    Agregar.RegistrarCurso(datos[0], credito);
                }
                contador++;
            }

            file.Close();

            if (System.IO.File.Exists(@Ruta))
            {
                try
                {
                    System.IO.File.Delete(Ruta);
                }
                catch (System.IO.IOException e)
                {
                    return;
                }
            }
        }
    }
}