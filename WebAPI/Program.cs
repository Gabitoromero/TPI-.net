using Domain.Model;
using Application.Services;
using Data;
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

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                    });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
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

            app.MapPatch("/usuarios/{id}", (int id, PatchUsuarioDTO dto) => 
            {
                FullUsuarioDTO userDto = usuarioService.Patch(id, dto);
                if (userDto == null)
                {
                     return Results.NotFound(new { message = "User not found" });
                }
                  return Results.Ok(userDto);
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
            /*
            // CRUD - Especialidad ---------------------------------------------------------------------------------------------------------------------------
            EspecialidadService especialidadService = new EspecialidadService();

            app.MapGet("/especialidades/{id}", (int id) =>
            {
                EspecialidadDTO dto = especialidadService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message = "User not found" });
                }

                return Results.Ok(dto);
            });

            app.MapGet("/especialidades/", () =>
            {
                List<EspecialidadDTO> usuariosDTO = especialidadService.GetAll();

                if (usuariosDTO.Count == 0)
                {
                    return Results.NotFound();
                }

                return Results.Ok(usuariosDTO);
            });

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

            app.MapPatch("/especialidades/{id}", (int id, EspecialidadDTO dto) =>
            {
                EspecialidadDTO userDto = especialidadService.Patch(id, dto);
                if (userDto == null)
                {
                    return Results.NotFound(new { message = "User not found" });
                }
                return Results.Ok(userDto);
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
            */
            app.Run();
        }
    }
}
