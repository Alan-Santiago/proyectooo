using deportes.COMMON.Entidades;
using deportes.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deportes.BIZ
{
    public class ManejadorUsuario : IManejadorUsuario
    {
        IRepositorio<Usuario> repositorio;
        public ManejadorUsuario(IRepositorio<Usuario> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Usuario> Listar => repositorio.Leer;

        public bool Agregar(Usuario entidad)
        {
            return repositorio.Crear(entidad);
        }

        public Usuario BuscarIdentificador(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Usuario entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
