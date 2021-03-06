﻿using System;
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
        public Boolean RegistrarPrerequisito(String curso, String prerrequisito)
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
        public Boolean VerificarPreCurso(String curso, String precurso)
        {
            String stg_sql = "SELECT COUNT(*)FROM PRERREQUISITO WHERE Curso = @Curso AND PreCurso = @PreCurso";
            try
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(stg_sql, Conexion);//ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@Nombre", curso); //enviamos los parametros
                cmd.Parameters.AddWithValue("@Nombre", precurso); //enviamos los parametros
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