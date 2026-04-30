
using Application.AuthServices;
using Application.Interfaces;
using Application.ProductServices;
using Application.UserServices;
using Infrastructure.Data;
using Infrastructure.Repositories.ProductRepositories;
using Infrastructure.Repositories.UserRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Jwt;
using Scalar.AspNetCore;


namespace RecapSecurity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<MyAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"))
            );

            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IProductRepository,ProductRepository>();

            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<IAuthService , AuthService>();

            // configuration pour le binding de la section JwtSettings du appSettings.json
            builder.Services.Configure<JwtSettings>(
                    builder.Configuration.GetSection("JwtSettings")
                );

            // configuration du token
            JwtSettings jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>()!;



            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // verifie la clé
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

                    // est-ce qu'on verifie l'issuer
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    // est-ce qu'on verifie l'Audience
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    // est-ce qu'on verifie la validité
                    ValidateLifetime = true,


                    // est-ce qu'on autorise une marge lors de la verification
                    ClockSkew = TimeSpan.Zero

                };
            }
            );

            builder.Services.AddAuthorization();

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
