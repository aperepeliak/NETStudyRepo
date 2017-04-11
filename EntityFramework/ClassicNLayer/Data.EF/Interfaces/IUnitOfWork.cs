using Data.EF.Models;
using System;

namespace Data.EF.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepo<Product>  Products { get; }
        IRepo<Category> Categories { get; }
        IRepo<Supplier> Suppliers { get; }

        void Save();
    }
}
