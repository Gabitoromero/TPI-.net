using Application.Services;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
            /*
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
            });*/
            // DI
            // NOTA: lo normal seria que dependan de una interaz, ejemplo IEspecialidadRepository, de forma que el dia de ma�ana si cambio a EspecialidadRepositoryV2 : IEspecialidadRepository
            // no tengo que cambiar casi nada, pero bueno, lo hicimos con la intencion de probar inyeccion de dependencias, la realidad es que no vamos a cambiar los repos

            builder.Services.AddDbContext<AcademiaContext>();
            builder.Services.AddScoped<EspecialidadRepository>();
            builder.Services.AddScoped<EspecialidadService>();
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
            builder.Services.AddScoped<InscripcionRepository>();

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
            app.MapCursoEndpoints();
            app.MapPlanEndpoints();
            app.MapComisionEndpoints();
            app.MapMateriaEndpoints();


            app.Run();

        }
    }
}

  
