using Application.Interfaces;
using Application.Tools;
using BCrypt.Net;
using Infrastructure.Repositories.UserRepositories;
using Microsoft.Extensions.Options;
using Models.AuthModels;
using Models.Jwt;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AuthServices
{
    public class AuthService(IUserRepository _repository,IOptions<JwtSettings> _jwtOptions) : IAuthService
    {
        public async Task<string> Login(LoginRequest loginForm)
        {
            User? u = await _repository.GetByEmailAsync(loginForm.Email);

            if(u == null || !BCrypt.Net.BCrypt.Verify(loginForm.Password,u.Password))
            {
                throw new UnauthorizedAccessException("Identifiants Invalides");
            }

            JwtTools helpers = new JwtTools(_jwtOptions);

            string token = helpers.GenerateToken(u.Email,u.Role);

            return token;

        }

        public async Task<string> Register(RegisterRequest registerForm)
        {
            // verifier si un utilisateur existe avec cet email
            User? existingUser = await _repository.GetByEmailAsync(registerForm.Email);

            if(existingUser != null)
            {
                throw new InvalidOperationException("Identifiants invalides !");
            }

            // hasher le mot de passe et créer un User
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerForm.Password);

            User userToAdd = new()
            {
                Email = registerForm.Email,
                Firstname = registerForm.Firstname,
                Lastname = registerForm.Lastname,
                Password = passwordHash
            };

            // Ajouter l'utilisateur
            User userCreated = await _repository.CreateAsync(userToAdd);

            // generation du token
            JwtTools helpers = new JwtTools(_jwtOptions);

            string token = helpers.GenerateToken(userCreated.Email,userCreated.Role);

            return token;
        }
    }
}