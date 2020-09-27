using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AmimirWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        AmimirEntities db = new AmimirEntities();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<STPR_ESTADO_LISTA_Result> estadoLista()
        {
            return db.STPR_ESTADO_LISTA_Result().ToList();
        }

        public STPR_ESTADO_LISTA_Result estadoDatos(int ID)
        {
            return (from u in db.STPR_ESTADO_LISTA_Result() where u.ID.Equals(ID) select u).FirstOrDefault();
        }

        public STPR_ESTADO_GUARDAR_Result estadoGuardar(string nombre)
        {
            return db.STPR_ESTADO_GUARDAR_Result(nombre).FirstOrDefault();
        }

        public STPR_ESTADO_EDITAR_Result estadoEditar(int ID, string nombre)
        {
            return db.STPR_ESTADO_EDITAR_Result(ID, nombre).FirstOrDefault();
        }

        public void estadoBorrar(int ID)
        {
            db.STPR_ESTADO_BORRAR_Result(ID);
        }


        public List<STPR_ANIME_LISTA_Result> animeLista()
        {
            return db.STPR_ANIME_LISTA_Result().ToList();
        }

        public STPR_ANIME_LISTA_Result animeDatos(int ID)
        {
            return (from u in db.STPR_ANIME_LISTA_Result() where u.ID.Equals(ID) select u).FirstOrDefault();
        }

        public STPR_ANIME_GUARDAR_Result animeGuardar(string Nombre, DateTime? FechaEstreno, 
            int? SecuelaID, int? PrecuelaID, string Sinopsis, Decimal Puntuacion, Decimal Popularidad, int EstadoID)
        {
            return db.STPR_ANIME_GUARDAR_Result(Nombre, FechaEstreno, SecuelaID, 
                PrecuelaID, Sinopsis, Puntuacion, 
                Popularidad, EstadoID).FirstOrDefault();
        }

        public STPR_ANIME_EDITAR_Result animeEditar(int ID, string Nombre, DateTime FechaEstreno,
            int? SecuelaID, int? PrecuelaID, string Sinopsis, Decimal Puntuacion, Decimal Popularidad, int EstadoID)
        {
            return db.STPR_ANIME_EDITAR_Result(ID, Nombre, FechaEstreno, SecuelaID, PrecuelaID, Sinopsis,
                Puntuacion, Popularidad, EstadoID).FirstOrDefault();
        }

        public void animeBorrar(int ID)
        {
            db.STPR_ANIME_BORRAR_Result(ID);
        }

        public List<STPR_CAPITULO_LISTA_Result> capituloLista()
        {
            return db.STPR_CAPITULO_LISTA_Result().ToList();
        }

        public STPR_CAPITULO_GUARDAR_Result capituloGuardar(int AnimeID, string Titulo, 
            int Duracion, string Sinopsis, int Orden, string FechaPublicado, string URL)
        {
            return db.STPR_CAPITULO_GUARDAR_Result(AnimeID, Titulo, Duracion, Sinopsis, 
                Orden, DateTime.Parse(FechaPublicado), URL).FirstOrDefault();
        }
    }
}
