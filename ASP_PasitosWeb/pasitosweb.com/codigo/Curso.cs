using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_PasitosWeb.pasitosweb.com.codigo
{
    public class Curso
    {

        SqlConnection Conexion = new SqlConnection("Data Source=STORMTK-PC;Initial Catalog=PASITOSWEB;Integrated Security=True");
        //SqlConnection Conexion = new SqlConnection("Data Source=FELIPEKD-PC;Initial Catalog=PASITOSWEB;Integrated Security=True");

        public Boolean RegistrarCurso(int curso, string nombre)
        {
            String stg_sql = "INSERT INTO CURSO(Codigo, Nombre) VALUES (@Codigo, @Nombre)";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);
                cmd.Parameters.AddWithValue("@Codigo", curso);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
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
        public Boolean VerificarCurso(int curso)
        {
            String stg_sql = "SELECT COUNT(*)FROM CURSO WHERE Codigo = @Codigo";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);//ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@Codigo", curso); //enviamos los parametros
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
            }
            return false;
        }
    }
}