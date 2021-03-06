﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericServiceLib
{
    [Serializable]
    public abstract class GenericRepo<T> where T : class, new()
    {
        public Entities Context { get; } = new Entities();
        protected List<T> Table;


        public T Add(T entity)
        {
            Table.Add(entity);
            return entity;
        }

        public bool Delete(T entity)
        {
            return Table.Remove(entity);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public void Save()
        {
            Context.SaveEntitiesToXml();
        }
    }
}
