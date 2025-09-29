using Application.Services;
using Data;
using DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// README: Por motivos que se nos escapan, y despues de DIAS de debuguear, 3 Ias de por medio y mas de 200 pruebas, no sabemos por que
// el middleware de token rechaza los tokens que son generados por si mismo y que ademas coinciden en formato a la perfeccion
// Nuestra teoria es que los paquetes instalados tienen algun conflicto extraño que no sabemos arreglar
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
            // NOTA: lo normal seria que dependan de una interaz, ejemplo IEspecialidadRepository, de forma que el dia de mañana si cambio a EspecialidadRepositoryV2 : IEspecialidadRepository
            // no tengo que cambiar casi nada, pero bueno, lo hicimos con la intencion de probar inyeccion de dependencias, la realidad es que no vamos a cambiar los repos

            builder.Services.AddDbContext<AcademiaContext>();
            builder.Services.AddScoped<EspecialidadRepository>();
            builder.Services.AddScoped<EspecialidadService>();
            builder.Services.AddScoped<ModuloRepository>();
            builder.Services.AddScoped<ModuloService>();
            builder.Services.AddScoped<UsuarioRepository>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<AuthService>();

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
            

            //PLANES CRUD ---------------------------------------------------------------------------------------------------------------------------
            app.MapGet("/planes/{id}", (int id) =>
            {
                PlanService planService = new PlanService();
                PlanDTO dto = planService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            });

            app.MapGet("/planes/", () =>
            {
                PlanService planService = new PlanService();
                List<PlanDTO> planesDTO = planService.GetAll();
                if (planesDTO.Count == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(planesDTO);
            });

            app.MapPost("/planes/", (PlanDTO dto) =>
            {
                try
                {
                    PlanService planService = new PlanService();
                    PlanDTO planDTO = planService.Add(dto);
                    return Results.Ok(planDTO);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });

            app.MapPut("/planes/", (PlanDTO dto) =>
            {
                try
                {
                    PlanService planService = new PlanService();
                    PlanDTO planDTO = planService.Update(dto);

                    return Results.Ok(planDTO);
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });

                }
            });

            app.MapDelete("/planes/{id}", (int id) =>
            {
                try
                {
                    PlanService planService = new PlanService();
                    planService.Delete(id);
                    return Results.Ok();
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });


            app.MapAuthEndpoints();
            app.MapEspecialidadEndpoints();
            app.MapUsuarioEndpoints();
            app.MapModuloEndpoints();
            

            app.Run();

        }
    }
}

  
