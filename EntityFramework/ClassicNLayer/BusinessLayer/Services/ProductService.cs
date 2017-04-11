using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.DTOs;
using Data.EF.Interfaces;
using Data.EF.Models;

namespace BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _db;
        public ProductService(IUnitOfWork db)
        {
            _db = db;
        }

        public void AddProduct(ProductDTO productDto)
        {
            _db.Products.Create(new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                SupplierId = productDto.SupplierId
            });

            _db.Save();
        }

        public ProductDTO GetProduct(int id)
        {
            var product = _db.Products.Get(id);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _db.Products.GetAll().Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId
            });
        }
        public IEnumerable<ProductDTO> GetProductsBy(Func<ProductDTO, bool> predicate)
        {
            Func<Product, bool> clause = p => predicate(new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId
            });

            return _db.Products.Find(clause).Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId
            });
        }
        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            return _db.Products.GetAll()
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    SupplierId = p.SupplierId
                });
        }
        public IEnumerable<ProductDTO> GetProductsBySupplier(int supplierId)
        {
            return _db.Products.GetAll()
                .Where(p => p.SupplierId == supplierId)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    SupplierId = p.SupplierId
                });
        }
    }
}
