using Domain.Model;
using Application.Services;
using DTOs;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //app builder que configura la app

            // Add services to the container.
            builder.Services.AddControllers();
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
                    return Results.NotFound();
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
            app.MapDelete("/usuarios/{id}", (int id) =>
            {
                Usuario userToDelete = UsuarioInMemory.Usuarios.Find(u => u.Id == id);
                if(userToDelete == null)
                {
                    return Results.BadRequest(new {error = $"User not found"} );
                }
                UsuarioInMemory.Usuarios.Remove(userToDelete);
                return Results.Ok(new { message = $"Deleted user succesfully: {userToDelete.Nombre}, {userToDelete.Apellido}" });
                
            });

            app.Run();
        }
    }
}
