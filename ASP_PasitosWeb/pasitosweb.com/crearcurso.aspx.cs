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
        codigo.Curso Registrar = new codigo.Curso();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            String codigo = txt_codigo.Text;
            String nombre = txt_nombre.Text;
            String requisito = txt_requisito.Text;

            if (codigo == null || nombre == null || codigo.Equals("") || nombre.Equals(""))//Si esta vacio
            {
                Response.Redirect("crearcurso.aspx?msg=1", false);
            }
            else
            {
                int numcodigo = Int32.Parse(codigo);
                if (Registrar.VerificarCurso(numcodigo))//Si el Curso Existe
                {
                    Response.Redirect("crearcurso.aspx?msg=2", false);
                }
                else //Si el Curso no Exite
                {
                    if (requisito == null || requisito.Equals("")) //requisito esta vacio o no
                    {
                        if (Registrar.RegistrarCurso(numcodigo, nombre))//Registrar Curso
                        {
                            Response.Redirect("crearcurso.aspx?msg=3", false);//Si se Registro
                        }
                        else
                        {
                            Response.Redirect("crearcurso.aspx?msg=4", false);//No se Registro
                        }
                    }
                    else
                    {
                        int numcrequisito = Int32.Parse(codigo);
                        if (Registrar.VerificarCurso(numcrequisito))//Verificar si Existe Prerequisito
                        {
                            if (Registrar.RegistrarCurso(numcodigo, nombre))//Registrar Curso
                            {
                                if (Registrar.RegistrarPrerequisito(numcodigo, numcrequisito))//Registrar Curso
                                {
                                    Response.Redirect("crearcurso.aspx?msg=3", false);//Si se Registro
                                }
                                else
                                {
                                    Response.Redirect("crearcurso.aspx?msg=4", false);//No se Registro
                                }
                            }
                            else
                            {
                                Response.Redirect("crearcurso.aspx?msg=4", false);//No se Registro
                            }
                        }
                        else
                        {
                            Response.Redirect("crearcurso.aspx?msg=5", false);//No Existe el Prerrequisito
                        }
                    }
                }


            }
        }
    }
}