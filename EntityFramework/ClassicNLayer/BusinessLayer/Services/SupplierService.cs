using BusinessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.DTOs;

// If using EF data layer
// using Data.EF.Interfaces;
// using Data.EF.Models;

// If using ADO.NET data layer
using Data.AdoNet.Interfaces;
using Data.AdoNet.Models;

namespace BusinessLayer.Services
{
    public class SupplierService : ISupplierService
    {
        private IUnitOfWork _db;
        public SupplierService(IUnitOfWork db)
        {
            _db = db;
        }

        public void AddSupplier(SupplierDTO supplierDto)
        {
            _db.Suppliers.Create(new Supplier
            {
                Name     = supplierDto.Name,
                Location = supplierDto.Location
            });

            _db.Save();
        }

        public SupplierDTO GetSupplier(int id)
        {
            var supplier = _db.Suppliers.Get(id);

            return new SupplierDTO
            {
                Id       = supplier.Id,
                Name     = supplier.Name,
                Location = supplier.Location
            };
        }

        public IEnumerable<SupplierDTO> GetSuppliers()
        {
            return _db.Suppliers.GetAll().Select(s => new SupplierDTO
            {
                Id       = s.Id,
                Name     = s.Name,
                Location = s.Location
            });
        }
    }
}
