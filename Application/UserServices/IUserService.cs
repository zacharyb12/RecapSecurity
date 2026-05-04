using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTOs>> GetAll();

        Task<UserDTOs?> GetByIdAsync(int id);

        Task<bool> UpdateAsync(UserDTOs updatedUser);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateRole(int id, string role);

    }
}
