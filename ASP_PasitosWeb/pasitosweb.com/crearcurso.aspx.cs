using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_PasitosWeb.pasitosweb.com
{
    public partial class manual : System.Web.UI.Page
    {
        codigo.curso Registrar = new codigo.curso();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            String credito = txt_credito.Text; //codgio curso
            String nombre = txt_nombre.Text; //nombre curso
            String requisito = txt_requisito.Text; //codigo requisito

            if (credito == null || nombre == null)//Si esta Vacio
            {
                Response.Redirect("crearcurso.aspx?msg=1", false);
            }
            else if (credito.Equals("") || nombre.Equals(""))
            {//Si no tiene nada escrito
                Response.Redirect("crearcurso.aspx?msg=1", false);
            }
            else if (requisito.Equals("") || requisito == null)// Si no esta Vacio y Tiene Algo escrito y
            {//Si Requisito esta Vacio
                if (Registrar.VerificarCurso(nombre))//Si se ha registrado
                {//Si esta registrado
                    Response.Redirect("crearcurso.aspx?msg=2", false);
                }
                else
                {//Si no esta Registrado
                    int numcredito = Int32.Parse(credito);
                    if (Registrar.RegistrarCurso(nombre, numcredito))//si el curso se pudo registrar
                    {
                        Response.Redirect("crearcurso.aspx?msg=3", false);
                    }
                    else
                    {
                        Response.Redirect("crearcurso.aspx?msg=4", false);
                    }
                }
            }
            else
            {//Si Requisito no esta Vacio
                if (Registrar.VerificarCurso(requisito))//
                {//Si el Requisito Existe
                    Response.Redirect("crearcurso.aspx?msg=3", false);
                }
                else
                {//Si Requisito no se a agregado a la base de datos
                    Response.Redirect("crearcurso.aspx?msg=5", false);
                }
            }

        }

    }
}