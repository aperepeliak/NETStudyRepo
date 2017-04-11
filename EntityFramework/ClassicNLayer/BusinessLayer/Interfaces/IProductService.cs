using BusinessLayer.DTOs;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductDTO productDto);
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsByCategory(int categoryId);
        IEnumerable<ProductDTO> GetProductsBySupplier(int supplierId);
        IEnumerable<ProductDTO> GetProductsBy(Func<ProductDTO, bool> predicate);
    }
}
