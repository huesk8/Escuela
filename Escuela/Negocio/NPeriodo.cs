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
    public class NPeriodo
    {

        public IEnumerable<Periodo> Periodo
        {
            get
            {
                string connetionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                List<Periodo> ltsPeriodo = new List<Periodo>();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    SqlCommand cmd = new SqlCommand("metodo_Periodo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Caso", "Mostrar");
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Periodo periodo = new Periodo();
                        periodo.id_periodo = Convert.ToInt32(rdr["id_periodo"]);
                        periodo.periodo = rdr["periodo"].ToString();

                        ltsPeriodo.Add(periodo);
                    }

                }

                return ltsPeriodo;
            }

        }


        public void AgregarPeriodo(string caso, Periodo periodo)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Periodo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                
                cmd.Parameters.AddWithValue("periodo", periodo.periodo);


                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


        public void ActualizarPeriodo(string caso, Periodo periodo)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Periodo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_periodo", periodo.id_periodo);
                cmd.Parameters.AddWithValue("periodo", periodo.periodo);


                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void EliminarPeriodo(string caso, int id)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Periodo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_periodo", id);


                con.Open();
                cmd.ExecuteNonQuery();
            }


        }


    }
}
