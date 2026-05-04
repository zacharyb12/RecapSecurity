using Infrastructure.Repositories.UserRepositories;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserServices
{
    public class UserService(IUserRepository _repository) : IUserService
    {

        public async Task<IEnumerable<UserDTOs>> GetAll()
        {
            IEnumerable<User> users = await _repository.GetAllAsync();

            IEnumerable<UserDTOs> usersDtos = users.Select(u =>
                    new UserDTOs()
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Firstname = u.Firstname,
                        Lastname = u.Lastname,
                        Role = u.Role
                    }
                );
            return usersDtos;
        }

        public async Task<UserDTOs?> GetByIdAsync(int id)
        {
            User? u =await _repository.GetByIdAsync(id);

            UserDTOs userToSend = new()
            {
                Id = u.Id,
                Email   =u.Email,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Role = u.Role
            };
            return userToSend;

        }

        public Task<bool> UpdateAsync(UserDTOs updatedUser)
        {
            User u = new()
            {
                Id = updatedUser.Id,
                Email = updatedUser.Email,
                Firstname = updatedUser.Firstname,
                Lastname = updatedUser.Lastname,

            };

            return _repository.UpdateAsync(u);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<bool> UpdateRole(int id ,string role)
        {
            return await _repository.UpdateRole(id,role);
        }
    }
}
