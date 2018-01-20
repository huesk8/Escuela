using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelado
{
    public class Control_Alumno:Periodo
    {
        public int id_control { get; set; }
        public int calificacion_final { get; set; }

        //public Clase CLASE { get; set; }
        public int? id_clase { get; set; }
        //public Periodo PERIODO { get; set; }
        public int? id_periodo { get; set; }
        //public Estudiante ESTUDIANTE { get; set; }
        public int? id_estudiante { get; set; }
    }
}
