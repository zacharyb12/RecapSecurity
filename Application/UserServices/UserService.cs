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
    }
}
