using deportes.COMMON.Entidades;
using deportes.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deportes.BIZ
{
    public class ManejadorDeportes : IManejadorDeportes
    {
        IRepositorio<CateDeportes> repositorio;
        public ManejadorDeportes(IRepositorio<CateDeportes> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<CateDeportes> Listar => repositorio.Leer;

        public bool Agregar(CateDeportes entidad)
        {
            return repositorio.Crear(entidad);
        }

        public CateDeportes BuscarIdentificador(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(CateDeportes entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
