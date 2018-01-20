using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelado
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string Nombre_completo { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Rol ROl { get; set; }
        public int? id_rol { get; set; }

    }
}
