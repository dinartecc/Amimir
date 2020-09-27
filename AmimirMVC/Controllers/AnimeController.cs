using AmimirMVC.Models;
using AmimirMVC.ServiceReferenceAmimir;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmimirMVC.Controllers
{
    public class AnimeController : Controller
    {
        Service1Client client = new Service1Client();

        public ActionResult Index()
        {
            var lista = client.animeLista();

            return View(lista);
        }

        public ActionResult Edit(int ID)
        {
            AnimeViewCLS tAnimeCLS = new AnimeViewCLS();

            var datos = client.animeDatos(ID);

            STPR_ESTADO_LISTA_Result[] estadoLista = client.estadoLista();
            List<EstadoCLS> ListaEstado = new List<EstadoCLS>();


            int estadoListaLength = estadoLista.Length;

            for (int i = 0; i < estadoListaLength; i++)
            {
                EstadoCLS estado = new EstadoCLS();
                estado.ID = estadoLista[i].ID;
                estado.nombre = estadoLista[i].nombre;
                ListaEstado.Add(estado);
            }

            tAnimeCLS.ListaEstado = ListaEstado;

            STPR_ANIME_LISTA_Result[] animeLista = client.animeLista();
            List<AnimeCLS> ListaAnime = new List<AnimeCLS>();


            int animeListaLength = animeLista.Length;

            for (int i = 0; i < animeListaLength; i++)
            {
                AnimeCLS anime = new AnimeCLS();
                anime.ID = animeLista[i].ID;
                anime.Nombre = animeLista[i].Nombre;
                ListaAnime.Add(anime);
            }

            tAnimeCLS.ListaAnime = ListaAnime;

            tAnimeCLS.ID = datos.ID;
            tAnimeCLS.Nombre = datos.Nombre;
            tAnimeCLS.FechaEstreno = datos.FechaEstreno != null ? datos.FechaEstreno.Value.ToString("dd/MM/yyyy") : " ";
            tAnimeCLS.SecuelaID = datos.SecuelaID;
            tAnimeCLS.Secuela = datos.Secuela;
            tAnimeCLS.PrecuelaID = datos.PrecuelaID;
            tAnimeCLS.Precuela = datos.Precuela;
            tAnimeCLS.Sinopsis = datos.Sinopsis;
            tAnimeCLS.Puntuacion = datos.Puntuacion;
            tAnimeCLS.Popularidad = datos.Popularidad;
            tAnimeCLS.EstadoID = (int)datos.EstadoID;
            tAnimeCLS.Estado = datos.Estado;

            return View(tAnimeCLS);
        }

        [HttpPost]
        public ActionResult Edit(AnimeCLS tAnimeCLS)
        {
            DateTime fecha = DateTime.ParseExact(tAnimeCLS.FechaEstreno, "dd/MM/yyyy", null);

            client.animeEditar(tAnimeCLS.ID, tAnimeCLS.Nombre, fecha, tAnimeCLS.SecuelaID, 
                tAnimeCLS.PrecuelaID, tAnimeCLS.Sinopsis, 
                tAnimeCLS.Puntuacion, tAnimeCLS.Popularidad, tAnimeCLS.EstadoID);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            AnimeCLS tAnimeCLS = new AnimeCLS();

            var datos = client.animeDatos(ID);

            tAnimeCLS.ID = datos.ID;
            tAnimeCLS.Nombre = datos.Nombre;
            tAnimeCLS.FechaEstreno = datos.FechaEstreno != null ? datos.FechaEstreno.Value.ToString("dd/MM/yyyy") : " ";
            tAnimeCLS.SecuelaID = datos.SecuelaID;
            tAnimeCLS.Secuela = datos.Secuela;
            tAnimeCLS.PrecuelaID = datos.PrecuelaID; 
            tAnimeCLS.Precuela = datos.Precuela;
            tAnimeCLS.Sinopsis = datos.Sinopsis;
            tAnimeCLS.Puntuacion = datos.Puntuacion;
            tAnimeCLS.Popularidad = datos.Popularidad;
            tAnimeCLS.EstadoID = (int)datos.EstadoID;
            tAnimeCLS.Estado = datos.Estado;

            return View(tAnimeCLS);
        }

        [HttpPost]
        public ActionResult Delete(AnimeCLS oAnimeCLS)
        {
            try
            {
            client.animeBorrar(oAnimeCLS.ID);

            return RedirectToAction("Index");
            }
            catch ( Exception e )
            {

                AnimeCLS tAnimeCLS = new AnimeCLS();

                var datos = client.animeDatos(oAnimeCLS.ID);

                tAnimeCLS.ID = datos.ID;
                tAnimeCLS.Nombre = datos.Nombre;
                tAnimeCLS.FechaEstreno = datos.FechaEstreno != null ? datos.FechaEstreno.Value.ToString("dd/MM/yyyy") : " ";
                tAnimeCLS.SecuelaID = datos.SecuelaID;
                tAnimeCLS.Secuela = datos.Secuela;
                tAnimeCLS.PrecuelaID = datos.PrecuelaID;
                tAnimeCLS.Precuela = datos.Precuela;
                tAnimeCLS.Sinopsis = datos.Sinopsis;
                tAnimeCLS.Puntuacion = datos.Puntuacion;
                tAnimeCLS.Popularidad = datos.Popularidad;
                tAnimeCLS.EstadoID = (int)datos.EstadoID;
                tAnimeCLS.Estado = datos.Estado;
                ViewBag.error = "Este anime es referenciado en otros registros. Por favor remover relación antes de eliminar.";
                return View(tAnimeCLS);
            }
        }

        public ActionResult Create()
        {
            AnimeViewCLS animeView = new AnimeViewCLS();

            STPR_ESTADO_LISTA_Result[] estadoLista = client.estadoLista();
            List<EstadoCLS> ListaEstado = new List<EstadoCLS>();


             int estadoListaLength = estadoLista.Length;

            for ( int i = 0; i < estadoListaLength; i++ )
            {
                EstadoCLS estado = new EstadoCLS();
                estado.ID = estadoLista[i].ID;
                estado.nombre = estadoLista[i].nombre;
                ListaEstado.Add(estado);
            }

            animeView.ListaEstado = ListaEstado;

            STPR_ANIME_LISTA_Result[] animeLista = client.animeLista();
            List<AnimeCLS> ListaAnime = new List<AnimeCLS>();


            int animeListaLength = animeLista.Length;

            for (int i = 0; i < animeListaLength; i++)
            {
                AnimeCLS anime = new AnimeCLS();
                anime.ID = animeLista[i].ID;
                anime.Nombre = animeLista[i].Nombre;
                ListaAnime.Add(anime);
            }

            animeView.ListaAnime = ListaAnime;

            return View(animeView);
        }

        [HttpPost]
        public ActionResult Create(AnimeCLS oAnimeCLS)
        {

            try
            {
                DateTime fecha = DateTime.ParseExact(oAnimeCLS.FechaEstreno, "dd/MM/yyyy", null);

                client.animeGuardar(oAnimeCLS.Nombre, fecha, oAnimeCLS.SecuelaID,
                    oAnimeCLS.PrecuelaID, oAnimeCLS.Sinopsis,
                    oAnimeCLS.Puntuacion, oAnimeCLS.Popularidad, oAnimeCLS.EstadoID);
            }
            catch {
                client.animeGuardar(oAnimeCLS.Nombre, null, oAnimeCLS.SecuelaID,
                    oAnimeCLS.PrecuelaID, oAnimeCLS.Sinopsis,
                    oAnimeCLS.Puntuacion, oAnimeCLS.Popularidad, oAnimeCLS.EstadoID);
            }
            

            return RedirectToAction("Index");
        }
    }
}