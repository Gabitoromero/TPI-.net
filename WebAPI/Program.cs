using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

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

            // DI
            // NOTA: lo normal seria que dependan de una interaz, ejemplo IEspecialidadRepository, de forma que el dia de mañana si cambio a EspecialidadRepositoryV2 : IEspecialidadRepository
            // no tengo que cambiar casi nada, pero bueno, lo hicimos con la intencion de probar inyeccion de dependencias, la realidad es que no vamos a cambiar los repos

            builder.Services.AddDbContext<AcademiaContext>();
            builder.Services.AddScoped<EspecialidadRepository>();
            builder.Services.AddScoped<EspecialidadService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

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

            // CRUD - Usuario ---------------------------------------------------------------------------------------------------------------------------
            

            app.MapGet("/usuarios/{id}", (int id) =>
            {
                UsuarioService usuarioService = new UsuarioService();
                FullUsuarioDTO dto = usuarioService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "User not found" });
                }

                return Results.Ok(dto);
            });

            app.MapGet("/usuarios/", () =>
            {
                UsuarioService usuarioService = new UsuarioService();
                List<ShowUsuarioDTO> usuariosDTO = usuarioService.GetAll();

                if (usuariosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Users do not exist" });
                }

                return Results.Ok(usuariosDTO);
            });

            app.MapPost("/usuarios/", (PostUsuarioDTO dto) =>
            {
                try
                {
                    UsuarioService usuarioService = new UsuarioService();
                    PostUsuarioDTO usuarioDTO = usuarioService.Add(dto);

                    return Results.Ok(usuarioDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            });

            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                try
                {
                    UsuarioService usuarioService = new UsuarioService();
                    usuarioService.Delete(id);
                    return Results.Ok();
                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }



            });

            app.MapPut("/usuarios/", (PutUsuarioDTO dto) =>
            { 
                try
                {
                    UsuarioService usuarioService = new UsuarioService();
                    PutUsuarioDTO userUpdated = usuarioService.Update(dto);
                    return Results.Ok(userUpdated);

                } catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }
            });


            // CRUD - Especialidad ---------------------------------------------------------------------------------------------------------------------------
            /*
            EspecialidadService especialidadService = new EspecialidadService();

            app.MapGet("/especialidades/{id}", (int id) =>
            {
                EspecialidadDTO dto = especialidadService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "Especialidad not found" });
                }

                return Results.Ok(dto);
            });//checked

            app.MapGet("/especialidades/", () =>
            {
                List<EspecialidadDTO> espDTO = especialidadService.GetAll();

                if (espDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Especialidad not found" });
                }

                return Results.Ok(espDTO);
            });//checked

            app.MapPost("/especialidades/", (NewEspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadDTO espDTO = especialidadService.Add(dto);

                    return Results.Ok(espDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            });

            app.MapDelete("/especialidades/{id}", (int id) =>
            {
                EspecialidadDTO espDeleted = especialidadService.Remove(id);
                if (espDeleted == null)
                {
                    return Results.NotFound(new { data = "Especialidad not found" });
                }
                return Results.Ok(espDeleted);


            });

            app.MapPut("/especialidades/", (EspecialidadDTO dto) =>
            {
                try
                {
                    EspecialidadService especialidadService = new EspecialidadService();
                    EspecialidadDTO userUpdated = especialidadService.Update(dto);
                    if (userUpdated == null) 
                    { 
                       return Results.NotFound(new { message = "Especialidad not found" });
                    }
                    return Results.Ok(userUpdated);

                } catch (ArgumentException er)
                {   
                    return Results.BadRequest(new { error = er.Message });
                } 


            });*/
            app.MapEspecialidadEndpoints();
 
            //CRUD - Modulo ---------------------------------------------------------------------------------------------------------------------------
            app.MapModuloEndpoints();

            app.Run();

        }
    }
}

  
