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
    public class NControl_Alumno
    {

        public IEnumerable<Control_Alumno> Control_Alumno
        {
            get
            {
                string connetionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                List<Control_Alumno> ltsControlAlumno = new List<Control_Alumno>();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    SqlCommand cmd = new SqlCommand("metodo_Control_Alumno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Caso", "Mostrar");
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Control_Alumno Control_Alumno = new Control_Alumno();
                        Control_Alumno.id_control = Convert.ToInt32(rdr["id_control"]);
                        Control_Alumno.periodo = rdr["periodo"].ToString();
                        Control_Alumno.clase = rdr["clase"].ToString();
                        Control_Alumno.nombre_completo = rdr["nombre_completo"].ToString();
                        Control_Alumno.calificacion_final = Convert.ToInt32(rdr["calificacion_final"]);


                        ltsControlAlumno.Add(Control_Alumno);
                    }

                }

                return ltsControlAlumno;
            }

        }


        public void AgregarControlAlumno(string caso, Control_Alumno Control_Alumno)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Control_Alumno", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                
                cmd.Parameters.AddWithValue("id_periodo", Control_Alumno.id_periodo);
                cmd.Parameters.AddWithValue("id_clase", Control_Alumno.id_clase);
                cmd.Parameters.AddWithValue("id_estudiante", Control_Alumno.id_estudiante);
                cmd.Parameters.AddWithValue("calificacion_final", Control_Alumno.calificacion_final);




                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


        public void ActualizarControlAlumno(string caso, Control_Alumno Control_Alumno)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Control_Alumno", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_control", Control_Alumno.id_control);
                cmd.Parameters.AddWithValue("id_periodo", Control_Alumno.id_periodo);
                cmd.Parameters.AddWithValue("id_clase", Control_Alumno.id_clase);
                cmd.Parameters.AddWithValue("id_estudiante", Control_Alumno.id_estudiante);
                cmd.Parameters.AddWithValue("calificacion_final", Control_Alumno.calificacion_final);


                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void EliminarControlAlumno(string caso, int id)
        {
            string ConexionString = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(ConexionString))
            {

                SqlCommand cmd = new SqlCommand("metodo_Control_Alumno", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Caso", caso);
                cmd.Parameters.AddWithValue("id_control", id);


                con.Open();
                cmd.ExecuteNonQuery();
            }


        }



    }
}
