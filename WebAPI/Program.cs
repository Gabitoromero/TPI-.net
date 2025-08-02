using Application.Services;
using Data;
using Domain.Model;
using DTOs.EspecialidadDTOs;
using DTOs.ModuloDTOs;
using DTOs.UsuarioDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using DTOs.UsuarioDTOs;
using DTOs.EspecialidadDTOs;

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
            
            // CRUD - Usuario ---------------------------------------------------------------------------------------------------------------------------
            UsuarioService usuarioService = new UsuarioService();

            app.MapGet("/usuarios/{id}", (int id) =>
            {
                FullUsuarioDTO dto = usuarioService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message= "User not found"});
                }

                return Results.Ok(dto); 
            }); //checked

            app.MapGet("/usuarios/", () =>
            {
                List<ShowUsuarioDTO> usuariosDTO = usuarioService.GetAll();

                if (usuariosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "User not found" });
                }

                return Results.Ok(usuariosDTO);
            }); //checked

            app.MapPost("/usuarios/", (PostUsuarioDTO dto) =>
            {
                try
                {
                    PostUsuarioDTO usuarioDTO = usuarioService.Add(dto);

                    return Results.Ok(usuarioDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            }); //checked

            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                ShowUsuarioDTO userDeleteded = usuarioService.Remove(id);
                if (userDeleteded == null)
                {
                    return Results.NotFound(new { data = "User not found" });
                }
                return Results.Ok(userDeleteded);


            }); //checked
            
            // CRUD - Especialidad ---------------------------------------------------------------------------------------------------------------------------
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
                    return Results.NotFound(new { data = "User not found" });
                }
                return Results.Ok(espDeleted);


            });


            //CRUD - Modulo ---------------------------------------------------------------------------------------------------------------------------
            ModuloService moduloService = new ModuloService();

            app.MapGet("/modulos/{id}", (int id) =>
            {
                ModuloDTO dto = moduloService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "Modulo not found" });
                }

                return Results.Ok(dto);
            });

            app.MapGet("/modulos/", () =>
            {
                List<ModuloDTO> modulosDTO = moduloService.GetAll();

                if (modulosDTO.Count == 0)
                {
                    return Results.NotFound(new { message = "Modulos not found" });
                }

            });
            
            app.Run();

        }
    }
}

  
