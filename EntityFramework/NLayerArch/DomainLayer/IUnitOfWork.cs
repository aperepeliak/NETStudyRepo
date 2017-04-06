using DomainLayer.Repos;

namespace DomainLayer
{
    public interface IUnitOfWork
    {
        IProductRepo Products { get; }
        ICategoryRepo Categories { get; }
        ISupplierRepo Suppliers { get; }

        void Complete();
    }
}
