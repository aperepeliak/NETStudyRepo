using BusinessLayer.DTOs;
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

        // This method only available using EF data layer
        //IEnumerable<ProductDTO> GetProductsBy(Func<ProductDTO, bool> predicate);
    }
}
