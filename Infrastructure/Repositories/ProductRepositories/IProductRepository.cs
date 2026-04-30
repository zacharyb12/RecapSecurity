using Models.ProductModels;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.ProductRepositories
{
    public interface IProductRepository
    {

        // GetById
        Task<Product?> GetByIdAsync(int id);

        // Create
        Task<bool> CreateAsync(Product newProduct);

        // Update
        Task<bool> UpdateAsync(Product updatedProduct);

        // Delete
        Task<bool> DeleteAsync(int id);

        // GetAll
        Task<IEnumerable<Product>> GetAllAsync();


        // GetAllByUserId
        Task<IEnumerable<Product>> GetAllByUserIdAsync(int id);
    }
}
