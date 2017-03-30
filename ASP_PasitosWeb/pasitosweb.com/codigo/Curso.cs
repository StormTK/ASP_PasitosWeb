using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_PasitosWeb.pasitosweb.com.codigo
{
    public class curso
    {

        SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=PASITOSWEB;Integrated Security=True");
        //SqlConnection Conexion = new SqlConnection("Data Source=FELIPEKD-PC;Initial Catalog=PASITOSWEB;Integrated Security=True");
        public String MostrarCursos()
        {
            String stg_sql = "SELECT * FROM CURSO ORDER BY Nombre";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                SqlDataReader resultado = cmd.ExecuteReader();
                String HTML = "<table><tr><th>Nombre</th><th>Credito</th><th>PreRequisito</th></tr>";
                while (resultado.Read())
                {
                    String codigo = resultado["Codigo"].ToString();
                    int numerocodigo = Int32.Parse(codigo);
                    
                    HTML += "<tr><td>" + resultado["Nombre"].ToString() + "</td>";
                    HTML += "<td>" + resultado["NoCredito"].ToString() + "</td>";
                    HTML += "<td>" + VerPrerequisito(numerocodigo) + "</td>"; 
                }
                HTML += "</table></div>";
                Conexion.Close();
                return HTML;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
                return "<p class=\"invalido\">:c <br />Error 404<br />No se Pudo Conectar al Servidor </p>";
            }
           
        }
        public String VerPrerequisito(int curso)
        {
            String stg_sql = "SELECT CURSO.Nombre FROM CURSO INNER JOIN PRERREQUISITO ON CURSO.Codigo = PRERREQUISITO.PreCurso WHERE PRERREQUISITO.Curso = @Curso";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@Curso", curso);
                SqlDataReader resultado = cmd.ExecuteReader();
                String prerequisito = "";
                while (resultado.Read())
                {
                    prerequisito +=  resultado["Nombre"].ToString() + ", ";

                }
                Conexion.Close();
                return prerequisito;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
                return MensajeError;
            }
        }
        public Boolean RegistrarCurso(string nombre, int credito)
        {
            String stg_sql = "INSERT INTO CURSO(Nombre, NoCredito) VALUES(@Nombre, @NoCredito)";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@NoCredito", credito);
                cmd.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
                return false;
            }
        }
        public Boolean RegistrarPrerequisito(int curso, int prerrequisito)
        {
            String stg_sql = "INSERT INTO PRERREQUISITO(Curso, PreCurso) VALUES (@Codigo, @PreRequisito)";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@Codigo", curso);
                cmd.Parameters.AddWithValue("@PreRequisito", prerrequisito);
                cmd.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
            }
            return false;
        }
        public int VerificarCodigoCurso(String nombre)
        {
            String stg_sql = "SELECT Codigo FROM CURSO WHERE Nombre = @Nombre";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);//ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@Nombre", nombre); //enviamos los parametros
                SqlDataReader resultado = cmd.ExecuteReader();
                resultado.Read();
                String codigo = resultado["codigo"].ToString();
                Conexion.Close();
                if (codigo == null || codigo.Equals(""))
                {
                    return 0;
                }
                else
                {
                    int numcodigo = Int32.Parse(codigo);
                    return numcodigo;
                }
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
                return 0;
            }
        }
        public Boolean VerificarCurso(string nombre)
        {
            String stg_sql = "SELECT COUNT(*)FROM CURSO WHERE Nombre = @Nombre";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);//ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@Nombre", nombre); //enviamos los parametros
                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada
                Conexion.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception DetalleError)
            {
                String MensajeError = "Insert Error:";
                MensajeError += DetalleError.Message;
                return false;
            }
        }
    }
}