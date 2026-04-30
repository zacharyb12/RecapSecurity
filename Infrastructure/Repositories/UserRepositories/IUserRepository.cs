using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        // GetByEmail
        Task<User?> GetByEmailAsync(string email);

        // GetById
        Task<User?> GetByIdAsync(int id);

        // Create
        Task<User> CreateAsync(User newUser);

        // Update
        Task<bool> UpdateAsync(User updatedUser);

        // Delete
        Task<bool> DeleteAsync(int id);

        // GetAll
        Task<IEnumerable<User>> GetAllAsync();
    }
}
