using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.UserRepositories
{
    public class UserRepository(MyAppContext _context) : IUserRepository
    {
        public async Task<User> CreateAsync(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            User? u = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(u == null)
            {
                return false;
            }

            _context.Users.Remove(u);

            int rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UpdateAsync(User updatedUser)
        {
            User? u = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);

            if(u == null)
            {
                return false;
            }

            u.Firstname = updatedUser.Firstname;
            u.Lastname = updatedUser.Lastname;
            u.Email = updatedUser.Email;

            int rowsEffected = await _context.SaveChangesAsync();

            return rowsEffected > 0;
        }
    }
}
