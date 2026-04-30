using Infrastructure.Data;
using Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.ProductRepositories
{
    public class ProductRepository(MyAppContext _context) : IProductRepository
    {
        public async Task<bool> CreateAsync(Product newProduct)
        {
            await _context.Products.AddAsync(newProduct);

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByUserIdAsync(int id)
        {
            return await _context.Products.Where(u => u.UserId == id).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product? p = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if(p == null)
            {
                return false;
            }

            _context.Remove(p);

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> UpdateAsync(Product updatedProduct)
        {
            Product? p = await _context.Products.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);

            if (p == null)
            {
                return false;
            }

            p.Name = updatedProduct.Name;
            p.Description = updatedProduct.Description;
            p.Price = updatedProduct.Price;
            p.ImageUrl = updatedProduct.ImageUrl;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

    }
}
