using Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequest registerForm);
        Task<string> Login(LoginRequest LoginForm);

        Task<bool> UpdatePassword(UpdatePasswordRequest request);
    }
}
