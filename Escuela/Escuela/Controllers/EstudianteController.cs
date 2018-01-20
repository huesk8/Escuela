using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelado;
using Negocio;


namespace Escuela.Controllers
{
    public class EstudianteController : Controller
    {

        private NEstudiante nEstudiante = new NEstudiante();
        //
        // GET: /Estudiante/

        public ActionResult Index()
        {

            List<Estudiante> ltsestudiante = nEstudiante.Estudiante.ToList();

            return View(ltsestudiante);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_post()
        {
            Estudiante estudiante = new Estudiante();

            TryUpdateModel(estudiante);

            if (ModelState.IsValid)
            {

                nEstudiante.AgregarEstudiante("Agregar", estudiante);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Estudiante estudiante = nEstudiante.Estudiante.Single(per => per.id_estudiante == id);
            return View(estudiante);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(int id)
        {

            Estudiante estudiante = nEstudiante.Estudiante.Single(per => per.id_estudiante == id);
            UpdateModel<Estudiante>(estudiante);
            if (ModelState.IsValid)
            {
                nEstudiante.ActualizarEstudiante("Actualizar", estudiante);
                return RedirectToAction("Index");

            }
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            nEstudiante.EliminarEstudiante("Eliminar", id);
            return RedirectToAction("Index");

        }

    }
}
