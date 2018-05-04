using deportes.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace deportes.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base
    {
        bool Crear(T entidad);
        bool Editar(T entidadModificada);
        bool Eliminar(ObjectId id);
        List<T> Leer { get; }

    }
}
