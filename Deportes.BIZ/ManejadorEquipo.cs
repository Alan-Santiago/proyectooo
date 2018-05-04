using deportes.COMMON.Entidades;
using deportes.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deportes.BIZ
{
    public class ManejadorEquipo : IManejadorEquipo
    {
        IRepositorio<Equipo> repositorio;
        public ManejadorEquipo(IRepositorio<Equipo> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Equipo> Listar => repositorio.Leer;

        public bool Agregar(Equipo entidad)
        {
            return repositorio.Crear(entidad);
        }

        public int Aleatorios(string pal)
        {
            int valor = ContadorDeBuscarEquipo(pal);
            Random a = new Random();
            int v = 0;
            return v = a.Next(1, valor);
        }

        public IEnumerable BuscarEquipos(string pal)
        {
            return Listar.Where(e => e.Deporte == pal).ToList();
        }

        public Equipo BuscarIdentificador(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public int ContadorDeBuscarEquipo(string pal)
        {
            return Listar.Where(e => e.Deporte == pal).ToList().Count();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Eliminar(id);
        }

        public bool Modificar(Equipo entidad)
        {
            return repositorio.Editar(entidad);
        }
    }
}
