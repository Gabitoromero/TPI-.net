using Domain.Model;
using Application.Services;
using DTOs;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            app.MapGet("/usuarios/{id}", (int id) =>
            {

                UsuarioService usuarioService = new UsuarioService();

                UsuarioDTO dto = usuarioService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto); 
            });

            app.MapGet("/usuarios/", () =>
            {
                UsuarioService usuarioService = new UsuarioService();

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
                    UsuarioService usuarioService = new UsuarioService();

                    UsuarioDTO usuarioDTO = usuarioService.Add(dto);

                    return Results.Ok(usuarioDTO);

                }
                catch (ArgumentException er)
                {
                    return Results.BadRequest(new { error = er.Message });
                }

            });

            app.Run();
        }
    }
}
