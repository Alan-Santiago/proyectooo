﻿using deportes.COMMON.Entidades;
using deportes.COMMON.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deportes.DAL
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : Base
    {
        private MongoClient client;
        private IMongoDatabase db;
        public RepositorioGenerico()
        {
            client = new MongoClient(new MongoUrl("mongodb://alan27:manzano19992710@ds111430.mlab.com:11430/torneoalan"));

            db = client.GetDatabase("torneoalan");
        }
        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Leer => Collection().AsQueryable().ToList();

        public bool Crear(T entidad)
        {
            try
            {
                Collection().InsertOne(entidad);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(T entidadModificada)
        {
            try
            {
                return Collection().ReplaceOne(p => p.Id == entidadModificada.Id, entidadModificada).ModifiedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(ObjectId id)
        {
            try
            {
                return Collection().DeleteOne(p => p.Id == id).DeletedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
