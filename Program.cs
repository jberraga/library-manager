using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1.Middlewares;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<AuthorsService>();
            builder.Services.AddScoped<BooksService>();
            builder.Services.AddScoped<BorrowsService>();
            builder.Services.AddScoped<CategoriesService>();
            builder.Services.AddScoped<UsersService>();
            
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            // Configure JWT Authentication
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? "fGEbuw9ja2kJiYghWFRp/cpXYV4NPInqCNeUKp7tD47v2tHDPRJsnLkf4LDb41O4/nHjYBrBLn1Rdas7SHpsB3OA=="; // dev only
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtSettings["Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            
            builder.Services.AddAuthorization();
            
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MyDbContext>();
            
            var app = builder.Build();
 
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
 
            app.UseHttpsRedirection();
            
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<SessionMiddleware>();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();
 
            app.Run();
        }
    }
}