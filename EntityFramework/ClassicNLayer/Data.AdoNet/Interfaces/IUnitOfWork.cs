using Data.AdoNet.Models;
using System;

namespace Data.AdoNet.Interfaces
{
    public interface IUnitOfWork
    {
        IRepo<Product>  Products   { get; }
        IRepo<Category> Categories { get; }
        IRepo<Supplier> Suppliers  { get; }

        void Save();
    }
}
