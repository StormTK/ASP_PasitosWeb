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
            int error = 0;
            int contador = 0;
            String Linea = "";

            System.IO.StreamReader file = new System.IO.StreamReader(@Ruta);

            while ((Linea = file.ReadLine()) != null)
            {
                if (contador > 0)
                {
                    string[] datos = Linea.Split(',');

                    String nombrecurso = datos[0];

                    int credito = Int32.Parse(datos[1]);

                    String nombrerequisito = datos[2];

                    if (Agregar.VerificarCurso(nombrerequisito))
                    {//Existe Prerrquisito
                        if (Agregar.VerificarCurso(nombrecurso))//Existe Curso
                        {//Si Existe
                            if (Agregar.RegistrarPrerequisito(nombrecurso, nombrerequisito))
                            {//Se registra Prerrequisito

                            }
                            else
                            {//No se Registra Prerrequisito
                                error++;
                            }
                        }
                        else
                        {//No Existe
                            if (Agregar.RegistrarCurso(nombrecurso, credito))//Se registra
                            {//si
                                if (Agregar.RegistrarPrerequisito(nombrecurso, nombrerequisito))
                                {//Se registra Prerrequisito

                                }
                                else
                                {
                                    error++;
                                }
                            }
                            else
                            {//no
                                error++;
                            }
                        }

                    }
                    else
                    {//No Existe Pre
                        error++;
                    }

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

            if(error > 0)
            {
                Response.Redirect("cargarcurso.aspx?msg=5", false);
            }
            else
            {
                Response.Redirect("cargarcurso.aspx?msg=3", false);
            }

        }
    }
}