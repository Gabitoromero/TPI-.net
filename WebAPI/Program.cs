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
                /*try
                {
                    Usuario user = UsuarioInMemory.Usuarios.Find(u => u.Id == id);
                    if (user == null)
                    {
                        return Results.NotFound(new { error = "User not found" });
                    }
                    if (dto.Id != null) { user.Id = dto.Id; }
                    if (dto.Nombre != null) { user.Nombre = dto.Nombre; }
                    if (dto.Apellido != null) { user.Apellido = dto.Apellido; }
                    if (dto.NombreUsuario != null) { user.NombreUsuario = dto.NombreUsuario; }
                    if (dto.Habilitado != null) { user.Habilitado = dto.Habilitado; }
                    if (dto.Email != null) { user.Email = dto.Email; }
                    if (dto.FechaAlta != null) { user.FechaAlta = dto.FechaAlta; }
                    if (dto.Clave != null) { user.Clave = dto.Clave; }
                    return Results.Ok();
                }catch(ArgumentException)
                {
                    return Results.BadRequest(new { message = "Bad Request"});
                }
                */
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
