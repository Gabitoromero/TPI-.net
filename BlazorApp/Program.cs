using BlazorApp.Components;
using BlazorApp.Services;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configurar licencia de QuestPDF (Community - Gratuita)
            QuestPDF.Settings.License = LicenseType.Community;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Configurar SignalR para manejar mensajes grandes (PDFs)
            builder.Services.AddServerSideBlazor()
                .AddHubOptions(options =>
                {
                    // Aumentar tamaño máximo de mensaje a 10MB (para PDFs grandes)
                    options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10 MB
                    
                    // Aumentar timeout del circuito para operaciones largas
                    options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
                    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
                });

            // Registrar AuthStateContainer como Scoped para notificaciones de cambio de estado
            builder.Services.AddScoped<AuthStateContainer>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
