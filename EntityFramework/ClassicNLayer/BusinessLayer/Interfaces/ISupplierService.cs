using BusinessLayer.DTOs;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ISupplierService
    {
        void AddSupplier(SupplierDTO supplierDto);
        SupplierDTO GetSupplier(int id);
        IEnumerable<SupplierDTO> GetSuppliers();
    }
}
