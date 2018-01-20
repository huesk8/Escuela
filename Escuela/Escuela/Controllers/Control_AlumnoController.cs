using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelado;
using Negocio;

namespace Escuela.Controllers
{
    public class Control_AlumnoController : Controller
    {

        private  NControl_Alumno ncontrol_Alumno = new NControl_Alumno();
        private NClase nclase = new NClase();
        private NPeriodo nPeriodo = new NPeriodo();
        private NEstudiante nEstudiante = new NEstudiante();
        
        
        //
        // GET: /Control_Alumno/

        public ActionResult Index()
        {
            List<Control_Alumno> ltsControl_Alumno = ncontrol_Alumno.Control_Alumno.ToList();

            return View(ltsControl_Alumno);
        }


        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Clase = new SelectList(nclase.Clase,"id_clase", "clase");
            ViewBag.Periodo = new SelectList(nPeriodo.Periodo, "id_Periodo", "periodo");
            ViewBag.Estudiante = new SelectList(nEstudiante.Estudiante, "id_Estudiante", "Nombre_completo");
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()
        {
            Control_Alumno control_Alumno = new Control_Alumno();

            TryUpdateModel(control_Alumno);

            if (ModelState.IsValid)
            {

                ncontrol_Alumno.AgregarControlAlumno("Agregar", control_Alumno);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Control_Alumno control_Alumno = ncontrol_Alumno.Control_Alumno.Single(per => per.id_control == id);
            return View(control_Alumno);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(int id)
        {

            Control_Alumno control_Alumno = ncontrol_Alumno.Control_Alumno.Single(per => per.id_control == id);
            UpdateModel<Control_Alumno>(control_Alumno);
            if (ModelState.IsValid)
            {
                ncontrol_Alumno.ActualizarControlAlumno("Actualizar", control_Alumno);
                return RedirectToAction("Index");

            }
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            ncontrol_Alumno.EliminarControlAlumno("Eliminar", id);
            return RedirectToAction("Index");

        }



    }
}
