using AmimirMVC.Models;
using AmimirMVC.ServiceReferenceAmimir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmimirMVC.Controllers
{
    public class EstadoController : Controller
    {

        Service1Client client = new Service1Client();

        public ActionResult Index()
        {
            var lista = client.estadoLista();

            return View(lista);
        }

        public ActionResult Edit(int ID)
        {
            EstadoCLS tEstadoCLS = new EstadoCLS();

            var datos = client.estadoDatos(ID);

            tEstadoCLS.ID = datos.ID;
            tEstadoCLS.nombre = datos.nombre;

            return View(tEstadoCLS);
        }

        [HttpPost]
        public ActionResult Edit(EstadoCLS tEstadoCLS)
        {
            client.estadoEditar(tEstadoCLS.ID, tEstadoCLS.nombre);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            EstadoCLS tEstadoCLS = new EstadoCLS();

            var datos = client.estadoDatos(ID);

            tEstadoCLS.ID = datos.ID;
            tEstadoCLS.nombre = datos.nombre;

            return View(tEstadoCLS);
        }

        [HttpPost]
        public ActionResult Delete(EstadoCLS tEstadoCLS)
        {
            client.estadoBorrar(tEstadoCLS.ID);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EstadoCLS oEstadoCLS)
        {
            client.estadoGuardar(oEstadoCLS.nombre);

            return RedirectToAction("Index");
        }
    }
}