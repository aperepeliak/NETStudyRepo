﻿using System.Collections.Generic;

using System.ServiceModel;

namespace GenericServiceLib
{
    [ServiceContract]
    public interface IGenericRepository<T> where T : class
    {
        [OperationContract]
        IEnumerable<T> GetAll();

        [OperationContract]
        T Add(T entity);

        [OperationContract]
        bool Delete(T entity);

        [OperationContract]
        void Edit(T entity);

        [OperationContract]
        void Save();
    }
}
