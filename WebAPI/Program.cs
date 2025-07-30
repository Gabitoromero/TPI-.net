using Domain.Model;
using Application.Services;
using DTOs;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

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

            UsuarioService usuarioService = new UsuarioService();

            app.MapGet("/usuarios/{id}", (int id) =>
            {
                UsuarioDTO dto = usuarioService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound(new { message= "User not found"});
                }

                return Results.Ok(dto); 
            });

            app.MapGet("/usuarios/", () =>
            {
                List<UsuarioDTO> usuariosDTO = usuarioService.GetAll();

                if (usuariosDTO.Count == 0)
                {
                    return Results.NotFound();
                }

                return Results.Ok(usuariosDTO);
            });

            app.MapPost("/usuarios/", (UsuarioDTO dto) =>
            {
                try
                {
                    UsuarioDTO usuarioDTO = usuarioService.Add(dto);

                    return Results.Ok(usuarioDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            });
            
            app.MapPatch("/usuarios/{id}", (int id, UsuarioDTO dto) => 
            {
                UsuarioDTO userDto = usuarioService.Patch(id, dto);
                if (userDto == null)
                {
                     return Results.NotFound(new { message = "User not found" });
                }
                  return Results.Ok(userDto);
            });

            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                UsuarioDeletedDTO userDeleteded = usuarioService.Remove(id);
                if (userDeleteded == null)
                {
                    return Results.NotFound(new { data = "User not found" });
                }
                return Results.Ok(userDeleteded);


            });

            app.Run();
        }
    }
}
