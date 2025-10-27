using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using DTOs;
using System.Reflection;

namespace BlazorApp.Reports
{
    public class PlanAlumnoReportDocument : IDocument
    {
        private readonly ReportePlanAlumnoDTO _datos;
        private readonly byte[] _logoBytes;

        public PlanAlumnoReportDocument(ReportePlanAlumnoDTO datos)
        {
            _datos = datos;
            _logoBytes = CargarLogo();
        }

        private byte[] CargarLogo()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "BlazorApp.Resources.academiaLuratiRomero.png";
                
                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                    return Array.Empty<byte>();
                
                using var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
            catch
            {
                return Array.Empty<byte>();
            }
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(40);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
        }

        private void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                // Logo y encabezado
                column.Item().Row(row =>
                {
                    if (_logoBytes.Length > 0)
                    {
                        row.ConstantItem(80).Image(_logoBytes);
                    }
                    
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().AlignCenter().Text("Universidad Tecnológica Nacional (UTN)")
                            .FontSize(16).Bold();
                        col.Item().AlignCenter().Text("Materia: Tecnologías de Desarrollo de Software IDE (.NET)")
                            .FontSize(12);
                    });
                });
                
                column.Item().PaddingVertical(10).LineHorizontal(1);
                
                // Título del reporte
                column.Item().AlignCenter().Text($"Plan de Estudios - {_datos.NombreCompleto}")
                    .FontSize(18).Bold();
            });
        }

        private void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Column(column =>
            {
                // Información del alumno y plan
                column.Item().Element(ComposeInformacion);
                column.Item().PaddingTop(15).Element(ComposeEstadisticas);
                column.Item().PaddingTop(15).Element(ComposeListaMaterias);
            });
        }

        private void ComposeInformacion(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Información del Alumno").FontSize(14).Bold();
                
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Text($"Legajo: {_datos.Legajo}");
                    row.RelativeItem().Text($"Nombre: {_datos.NombreCompleto}");
                });
                
                column.Item().PaddingTop(10).Background(Colors.Grey.Lighten3).Padding(8).Text("Información del Plan").FontSize(14).Bold();
                
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Text($"Plan: {_datos.NombrePlan}");
                    row.RelativeItem().Text($"Especialidad: {_datos.NombreEspecialidad}");
                });
            });
        }

        private void ComposeEstadisticas(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Estadísticas").FontSize(14).Bold();
                
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Total de Materias del Plan: {_datos.TotalMateriasPlan}").Bold();
                    });
                    
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Materias Aprobadas: {_datos.MateriasAprobadas}").FontColor(Colors.Green.Darken2).Bold();
                    });
                });
            });
        }

        private void ComposeListaMaterias(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Materias del Plan").FontSize(14).Bold();
                
                if (_datos.Materias.Count == 0)
                {
                    column.Item().PaddingTop(5).Text("No hay materias en el plan").Italic();
                    return;
                }
                
                column.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.ConstantColumn(120);
                        columns.ConstantColumn(120);
                    });
                    
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Materia").FontSize(10).Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Horas Semanales").FontSize(10).Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Condición").FontSize(10).Bold();
                    });
                    
                    foreach (var materia in _datos.Materias)
                    {
                        var colorFondo = materia.Condicion == "Aprobado" ? Colors.Green.Lighten4 :
                                        materia.Condicion == "Cursando" ? Colors.Blue.Lighten4 :
                                        materia.Condicion == "Reprobado" ? Colors.Red.Lighten4 :
                                        Colors.White;
                        
                        table.Cell().Background(colorFondo).BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(materia.NombreMateria).FontSize(9);
                        table.Cell().Background(colorFondo).BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(materia.HorasSemanales.ToString()).FontSize(9);
                        table.Cell().Background(colorFondo).BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(materia.Condicion).FontSize(9);
                    }
                });
            });
        }

        private void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text(text =>
            {
                text.Span($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(9);
            });
        }
    }
}
