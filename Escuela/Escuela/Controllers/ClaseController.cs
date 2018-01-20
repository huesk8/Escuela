using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelado;
using Negocio;


namespace Escuela.Controllers
{
    public class ClaseController : Controller
    {

        private NClase nClase = new NClase();
        //
        // GET: /Clase/

        public ActionResult Index()
        {
            List<Clase> ltsClase = nClase.Clase.ToList();

            return View(ltsClase);
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
            Clase clase = new Clase();

            TryUpdateModel(clase);

            if (ModelState.IsValid)
            {

                nClase.AgregarClase("Agregar", clase);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Clase clase = nClase.Clase.Single(per => per.id_clase == id);
            return View(clase);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(int id)
        {

            Clase clase = nClase.Clase.Single(per => per.id_clase == id);
            UpdateModel<Clase>(clase);
            if (ModelState.IsValid)
            {
                nClase.ActualizarClase("Actualizar", clase);
                return RedirectToAction("Index");

            }
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            nClase.EliminarClase("Eliminar", id);
            return RedirectToAction("Index");

        }


    }
}
