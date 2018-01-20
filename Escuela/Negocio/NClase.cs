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
    public class NClase
    {

        public IEnumerable<Clase> Clase
        {
            get
            {
                string connetionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                List<Clase> ltsClase = new List<Clase>();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    SqlCommand cmd = new SqlCommand("metodo_clase", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Caso", "Mostrar");
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Clase clase = new Clase();
                        clase.id_clase = Convert.ToInt32(rdr["id_clase"]);
                        clase.clase = rdr["clase"].ToString();

                        ltsClase.Add(clase);
                    }

                }

                return ltsClase;
            }

        }


        public void AgregarClase(string caso, Clase clase)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_clase", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
              
                cmd.Parameters.AddWithValue("Clase", clase.clase);
                

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


        public void ActualizarClase(string caso, Clase clase)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_clase", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_clase", clase.id_clase);
                cmd.Parameters.AddWithValue("clase", clase.clase);
              

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void EliminarClase(string caso, int id)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_clase", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_clase", id);


                con.Open();
                cmd.ExecuteNonQuery();
            }


        }

    }
}
