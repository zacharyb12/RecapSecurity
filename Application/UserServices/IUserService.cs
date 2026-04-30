using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTOs>> GetAll();
    }
}
