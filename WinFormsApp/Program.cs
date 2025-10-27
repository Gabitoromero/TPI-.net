using WinFormsApp;
using QuestPDF.Infrastructure;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar licencia de QuestPDF (Community - Gratuita)
            QuestPDF.Settings.License = LicenseType.Community;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm()); // Start the application with the Menu form
        }
    }
}