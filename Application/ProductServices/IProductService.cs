using Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductServices
{
    public interface IProductService
    {
        // GetById
        Task<ProductLightDTOs?> GetByIdAsync(int id);

        // Create
        Task<bool> CreateAsync(CreateProductDTOs newProduct);

        // Update
        Task<bool> UpdateAsync(UpdateProductDtos updatedProduct);

        // Delete
        Task<bool> DeleteAsync(int id);

        // GetAll
        Task<IEnumerable<ProductLightDTOs>> GetAllAsync();


        // GetAllByUserId
        Task<IEnumerable<ProductLightDTOs>> GetAllByUserIdAsync(int id);
    }
}
