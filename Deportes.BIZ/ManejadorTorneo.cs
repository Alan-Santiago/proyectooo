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
    public class ManejadorTorneo : IManejadorTorneo
    {
        IRepositorio<Torneo> torneo;
        public ManejadorTorneo(IRepositorio<Torneo> torneo)
        {
            this.torneo = torneo;
        }

        public List<Torneo> Listar => torneo.Leer;

        public bool Agregar(Torneo entidad)
        {
            return torneo.Crear(entidad);
        }

        public Torneo BuscarIdentificador(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        
        public bool Eliminar(ObjectId id)
        {
            return torneo.Eliminar(id);
        }

        public bool Modificar(Torneo entidad)
        {
            return torneo.Editar(entidad);
        }

        public int VerificarSiEsNumero(string text)
        {
            foreach (var item in text)
            {
                if (!(char.IsNumber(item)))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 1;
        }
    }
}
