using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelado;
using Negocio;

namespace Escuela.Controllers
{
    public class PeriodoController : Controller
    {

        private NPeriodo nPeriodo = new NPeriodo();
        //
        // GET: /Periodo/

        public ActionResult Index()
        {
            List<Periodo> ltsPeriodo = nPeriodo.Periodo.ToList();

            return View(ltsPeriodo);
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
            Periodo periodo = new Periodo();

            TryUpdateModel(periodo);

            if (ModelState.IsValid)
            {

                nPeriodo.AgregarPeriodo("Agregar", periodo);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Periodo periodo = nPeriodo.Periodo.Single(per => per.id_periodo == id);
            return View(periodo);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_post(int id)
        {

            Periodo periodo = nPeriodo.Periodo.Single(per => per.id_periodo == id);
            UpdateModel<Periodo>(periodo);
            if (ModelState.IsValid)
            {
                nPeriodo.ActualizarPeriodo("Actualizar", periodo);
                return RedirectToAction("Index");

            }
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            nPeriodo.EliminarPeriodo("Eliminar", id);
            return RedirectToAction("Index");

        }



    }
}
