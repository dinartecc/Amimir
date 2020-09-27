using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AmimirWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<STPR_ESTADO_LISTA_Result> estadoLista();

        [OperationContract]
        STPR_ESTADO_GUARDAR_Result estadoGuardar(string nombre);

        [OperationContract]
        STPR_ESTADO_LISTA_Result estadoDatos(int ID);

        [OperationContract]
        STPR_ESTADO_EDITAR_Result estadoEditar(int ID, string nombre);

        [OperationContract]
        void estadoBorrar(int ID);

        [OperationContract]
        List<STPR_ANIME_LISTA_Result> animeLista();

        [OperationContract]
        STPR_ANIME_GUARDAR_Result animeGuardar(string Nombre, DateTime? FechaEstreno,
            int? SecuelaID, int? PrecuelaID, string Sinopsis, Decimal Puntuacion, Decimal Popularidad, int EstadoID);

        [OperationContract]
        STPR_ANIME_LISTA_Result animeDatos(int ID);

        [OperationContract]
        STPR_ANIME_EDITAR_Result animeEditar(int ID, string Nombre, DateTime FechaEstreno,
            int? SecuelaID, int? PrecuelaID, string Sinopsis, Decimal Puntuacion, Decimal Popularidad, int EstadoID);

        [OperationContract]
        void animeBorrar(int ID);

        [OperationContract]
        List<STPR_CAPITULO_LISTA_Result> capituloLista();

        [OperationContract]
        STPR_CAPITULO_GUARDAR_Result capituloGuardar(int AnimeID, string Titulo,
            int Duracion, string Sinopsis, int Orden, string FechaPublicado, string URL);
    }
}
