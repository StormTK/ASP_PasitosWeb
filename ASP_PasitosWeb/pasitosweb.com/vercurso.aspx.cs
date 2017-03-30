using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_PasitosWeb.pasitosweb.com
{
    public partial class vercurso : System.Web.UI.Page
    {
        codigo.curso Mostrar = new codigo.curso();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected String MostrarCurso()
        {
            return Mostrar.MostrarCursos();
        }
    }
}