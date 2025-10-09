using Application.Services;
using Data;
using DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// README: Por motivos que se nos escapan, y despues de DIAS de debuguear, no sabemos por que
// el middleware de token rechaza los tokens que son generados por si mismo y que ademas coinciden en formato a la perfeccion
// Nuestra teoria es que los paquetes instalados tienen algun conflicto extra�o que no sabemos arreglar
// Asi que por el momento el middleware de autentitacion esta bypaseado y sin efecto.
// Realmente no tenemos ni idea que pasa y ya probamos de todo, asi que si alguien sabe que puede ser, se agradece la ayuda
// https://jwt.io/ valida correctamente tanto los tokens generados como los que le llegan al back, pero por algun motivo el back los rechaza

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args); //app builder que configura la app
            builder.Services.AddControllers(); // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            builder.Services.AddAuthorization();

            // DI
            // NOTA: lo normal seria que dependan de una interaz, ejemplo IEspecialidadRepository, de forma que el dia de ma�ana si cambio a EspecialidadRepositoryV2 : IEspecialidadRepository
            // no tengo que cambiar casi nada, pero bueno, lo hicimos con la intencion de probar inyeccion de dependencias, la realidad es que no vamos a cambiar los repos

            builder.Services.AddDbContext<AcademiaContext>();
            builder.Services.AddScoped<EspecialidadRepository>();
            builder.Services.AddScoped<EspecialidadService>();
            builder.Services.AddScoped<ModuloRepository>();
            builder.Services.AddScoped<ModuloService>();
            builder.Services.AddScoped<PlanRepository>();
            builder.Services.AddScoped<PlanService>();
            builder.Services.AddScoped<UsuarioRepository>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<CursoService>();
            builder.Services.AddScoped<CursoRepository>();
            builder.Services.AddScoped<ComisionRepository>();
            builder.Services.AddScoped<ComisionService>();
            builder.Services.AddScoped<MateriaRepository>();
            builder.Services.AddScoped<MateriaService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
          


            app.MapAuthEndpoints();
            app.MapEspecialidadEndpoints();
            app.MapUsuarioEndpoints();
            app.MapModuloEndpoints();
            app.MapCursoEndpoints();
            app.MapPlanEndpoints();
            app.MapComisionEndpoints();
            app.MapMateriaEndpoints();


            app.Run();

        }
    }
}

  
