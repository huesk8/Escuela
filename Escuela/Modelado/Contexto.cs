using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelado
{
    public class Contexto:DbContext 
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Control_Alumno> Control_Alumnos { get; set; }

    }
}
