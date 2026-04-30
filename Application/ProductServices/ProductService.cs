using Infrastructure.Repositories.ProductRepositories;
using Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductServices
{
    public class ProductService(IProductRepository _repository) : IProductService
    {
        public async Task<bool> CreateAsync(CreateProductDTOs newProduct)
        {
            Product p = new()
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price,
                UserId = newProduct.UserId,
                ImageUrl = newProduct.ImageUrl ?? null
            };

            return await _repository.CreateAsync(p);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductLightDTOs>> GetAllAsync()
        {
            IEnumerable<Product> products = await _repository.GetAllAsync();

            IEnumerable<ProductLightDTOs> productsToSend = products.Select(p =>
                        new ProductLightDTOs()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            Price = p.Price,
                            UserId = p.UserId,
                            ImageUrl = p.ImageUrl ?? null
                        }
            ).ToList();

            return productsToSend;
        }

        public async Task<IEnumerable<ProductLightDTOs>> GetAllByUserIdAsync(int id)
        {
            IEnumerable<Product> products = await _repository.GetAllByUserIdAsync(id);

            IEnumerable<ProductLightDTOs> productsToSend = products.Select(p =>
                        new ProductLightDTOs()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Description = p.Description,
                            Price = p.Price,
                            UserId = p.UserId,
                            ImageUrl = p.ImageUrl ?? null
                        }
            ).ToList();

            return productsToSend;
        }

        public async Task<ProductLightDTOs?> GetByIdAsync(int id)
        {
            Product? p = await _repository.GetByIdAsync(id);

            if(p == null)
            {
                return null;
            }

            ProductLightDTOs productToSend = new()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                UserId = p.UserId,
                ImageUrl = p.ImageUrl ?? null
            };

            return productToSend;
        }

        public async Task<bool> UpdateAsync(UpdateProductDtos updatedProduct)
        {
            Product p = new()
            {
                Id = updatedProduct.Id,
                Name= updatedProduct.Name,
                Description = updatedProduct.Description,
                Price = updatedProduct.Price,
                ImageUrl = updatedProduct.ImageUrl ?? null,
                UserId = updatedProduct.UserId
                
            };

            return await _repository.UpdateAsync(p);
        }
    }
}
