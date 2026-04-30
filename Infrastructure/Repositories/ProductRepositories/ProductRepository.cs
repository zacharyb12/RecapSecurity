using Infrastructure.Data;
using Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.ProductRepositories
{
    public class ProductRepository(MyAppContext _context) : IProductRepository
    {
        public async Task<Product> CreateAsync(Product newProduct)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Product>> GetAllByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAsync(Product updatedProduct)
        {
            throw new NotImplementedException();
        }

    }
}
