using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelado
{
    public class Estudiante
    {
        public int id_estudiante { get; set; }
        public string nombre_completo { get; set; }
       
        public DateTime fecha_nac { get; set; }
        //public Genero GENERO { get; set; } 
        public int? genero { get; set; }
    }
}
