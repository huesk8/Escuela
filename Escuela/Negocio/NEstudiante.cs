using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelado;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Negocio
{
    public class NEstudiante
    {
        public IEnumerable<Estudiante> Estudiante
        {
            get
            {
                string connetionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                List<Estudiante> ltsEstudiante = new List<Estudiante>();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    SqlCommand cmd = new SqlCommand("metodo_Estudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Caso", "Mostrar");
                    con.Open();
                   
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Estudiante estudiante = new Estudiante();
                        estudiante.id_estudiante = Convert.ToInt32(rdr["id_estudiante"]);
                        estudiante.nombre_completo = rdr["nombre_completo"].ToString();
                        estudiante.genero = Convert.ToInt16(rdr["genero"]);
                        estudiante.fecha_nac =Convert.ToDateTime(rdr["fecha_nac"]);
                       

                        ltsEstudiante.Add(estudiante);
                    }

                }

                return ltsEstudiante;
            }
            
        }

        public void AgregarEstudiante(string caso,Estudiante estudiante)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Estudiante", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("Nombre_Completo", estudiante.nombre_completo);
                cmd.Parameters.AddWithValue("Genero", estudiante.genero);
                cmd.Parameters.AddWithValue("Fecha_Nac", estudiante.fecha_nac);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


        public void ActualizarEstudiante(string caso, Estudiante estudiante)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Estudiante", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_estudiante", estudiante.id_estudiante);
                cmd.Parameters.AddWithValue("Nombre_Completo", estudiante.nombre_completo);
                cmd.Parameters.AddWithValue("Genero", estudiante.genero);
                cmd.Parameters.AddWithValue("Fecha_Nac", estudiante.fecha_nac);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void EliminarEstudiante(string caso, int id)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Estudiante", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_estudiante", id);


                con.Open();
                cmd.ExecuteNonQuery();
            }


        }

    }
}
