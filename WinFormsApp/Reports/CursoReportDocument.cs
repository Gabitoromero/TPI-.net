using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using DTOs;
using System.Reflection;

namespace WinFormsApp.Reports
{
    public class CursoReportDocument : IDocument
    {
        private readonly ReporteCursoDTO _datos;
        private readonly byte[] _logoBytes;

        public CursoReportDocument(ReporteCursoDTO datos)
        {
            _datos = datos;
            _logoBytes = CargarLogo();
        }

        private byte[] CargarLogo()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "WinFormsApp.Resources.academiaLuratiRomero.png";
                
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
                
                column.Item().AlignCenter().Text($"Reporte de Curso - {_datos.NombreMateria}")
                    .FontSize(18).Bold();
                
                column.Item().PaddingTop(5).Text($"Comisión: {_datos.DescripcionComision} | Año: {_datos.AnioCalendario}")
                    .FontSize(11);
            });
        }

        private void ComposeContent(IContainer container)
        {
            container.PaddingVertical(10).Column(column =>
            {
                column.Item().Element(ComposeInformacionGeneral);
                column.Item().PaddingTop(15).Element(ComposeEstadisticas);
                column.Item().PaddingTop(15).Element(ComposeGraficos);
                column.Item().PaddingTop(15).Element(ComposeListaProfesores);
                column.Item().PaddingTop(15).Element(ComposeListaAlumnos);
            });
        }

        private void ComposeInformacionGeneral(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Información del Curso").FontSize(14).Bold();
                
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Text($"Cupo Total: {_datos.CupoTotal}");
                    row.RelativeItem().Text($"Inscriptos: {_datos.TotalInscriptos}");
                    row.RelativeItem().Text($"Disponibles: {_datos.CupoTotal - _datos.TotalInscriptos}");
                });
            });
        }

        private void ComposeEstadisticas(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Estadísticas de Notas").FontSize(14).Bold();
                
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Promedio General: {_datos.PromedioGeneral:F2}").Bold();
                        col.Item().Text($"Total con Nota: {_datos.TotalAprobados + _datos.TotalReprobados}");
                    });
                    
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Aprobados: {_datos.TotalAprobados}").FontColor(Colors.Green.Darken2);
                        col.Item().Text($"Reprobados: {_datos.TotalReprobados}").FontColor(Colors.Red.Darken2);
                    });
                    
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Sin Nota: {_datos.TotalSinNota}").FontColor(Colors.Orange.Darken2);
                    });
                });
            });
        }

        private void ComposeGraficos(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Distribución de Notas").FontSize(14).Bold();
                
                column.Item().PaddingTop(10).Text("Porcentaje por Condición").FontSize(12).Bold();
                column.Item().PaddingTop(5).Row(row =>
                {
                    if (_datos.PorcentajeAprobados > 0)
                    {
                        row.RelativeItem((float)_datos.PorcentajeAprobados).Background(Colors.Green.Lighten2)
                            .Padding(5).Text($"Aprobados: {_datos.PorcentajeAprobados:F1}%").FontSize(10);
                    }
                    if (_datos.PorcentajeReprobados > 0)
                    {
                        row.RelativeItem((float)_datos.PorcentajeReprobados).Background(Colors.Red.Lighten2)
                            .Padding(5).Text($"Reprobados: {_datos.PorcentajeReprobados:F1}%").FontSize(10);
                    }
                    if (_datos.PorcentajeSinNota > 0)
                    {
                        row.RelativeItem((float)_datos.PorcentajeSinNota).Background(Colors.Orange.Lighten2)
                            .Padding(5).Text($"Sin Nota: {_datos.PorcentajeSinNota:F1}%").FontSize(10);
                    }
                });
                
                column.Item().PaddingTop(15).Text("Distribución por Rango de Notas").FontSize(12).Bold();
                column.Item().PaddingTop(5).Row(row =>
                {
                    foreach (var rango in _datos.DistribucionNotas)
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Background(Colors.Blue.Lighten3).Padding(5)
                                .AlignCenter().Text(rango.Key).FontSize(10);
                            col.Item().Background(Colors.Blue.Lighten4).Padding(5)
                                .AlignCenter().Text($"{rango.Value} alumnos").FontSize(9);
                        });
                    }
                });
            });
        }

        private void ComposeListaProfesores(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Profesores Asignados").FontSize(14).Bold();
                
                if (_datos.Profesores.Count == 0)
                {
                    column.Item().PaddingTop(5).Text("No hay profesores asignados").Italic();
                    return;
                }
                
                column.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(80);
                        columns.RelativeColumn();
                        columns.ConstantColumn(120);
                    });
                    
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Legajo").FontSize(10).Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Nombre").FontSize(10).Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Cargo").FontSize(10).Bold();
                    });
                    
                    foreach (var profesor in _datos.Profesores)
                    {
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(profesor.Legajo.ToString()).FontSize(9);
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(profesor.Nombre).FontSize(9);
                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(profesor.Cargo).FontSize(9);
                    }
                });
            });
        }

        private void ComposeListaAlumnos(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Lighten3).Padding(8).Text("Listado de Alumnos").FontSize(14).Bold();
                
                if (_datos.Alumnos.Count == 0)
                {
                    column.Item().PaddingTop(5).Text("No hay alumnos inscriptos").Italic();
                    return;
                }
                
                column.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(70);
                        columns.RelativeColumn();
                        columns.ConstantColumn(100);
                        columns.ConstantColumn(60);
                    });
                    
                    table.Header(header =>
                    {
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Legajo").FontSize(10).Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Alumno").FontSize(10).Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Condición").FontSize(10).Bold();
                        header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Nota").FontSize(10).Bold();
                    });
                    
                    foreach (var alumno in _datos.Alumnos.OrderBy(a => a.Alumno))
                    {
                        var colorFondo = alumno.Condicion == "Aprobado" ? Colors.Green.Lighten4 :
                                        alumno.Condicion == "Reprobado" ? Colors.Red.Lighten4 :
                                        Colors.White;
                        
                        table.Cell().Background(colorFondo).BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(alumno.Legajo.ToString()).FontSize(9);
                        table.Cell().Background(colorFondo).BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(alumno.Alumno).FontSize(9);
                        table.Cell().Background(colorFondo).BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(alumno.Condicion).FontSize(9);
                        table.Cell().Background(colorFondo).BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                            .Padding(5).Text(alumno.Nota?.ToString() ?? "-").FontSize(9);
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
