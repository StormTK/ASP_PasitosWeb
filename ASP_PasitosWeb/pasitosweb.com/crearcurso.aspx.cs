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
            int numcodigo = Int32.Parse(codigo);
            String nombre = txt_nombre.Text;
            if (Registrar.RegistrarCurso(numcodigo, nombre))
            {
                Response.Redirect("index.aspx", false);
            }
        }
    }
}