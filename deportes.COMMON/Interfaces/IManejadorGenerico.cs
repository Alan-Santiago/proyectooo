using deportes.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace deportes.COMMON.Interfaces
{
   public  interface IManejadorGenerico<T> where T:Base
    {
        bool Agregar(T entidad);
        bool Modificar(T entidad);
        bool Eliminar(ObjectId id);
        List<T> Listar { get; }
        T BuscarIdentificador(ObjectId id);

    }
}
