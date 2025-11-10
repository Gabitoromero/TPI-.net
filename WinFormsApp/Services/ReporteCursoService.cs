using DTOs;
using API.Clients;

namespace WinFormsApp.Services
{
    public class ReporteCursoService
    {
        public static async Task<ReporteCursoDTO> ObtenerDatosReporteAsync(NewCursoDTO curso)
        {
            var alumnos = await APIUsuario.GetAlumnosByCursoAsync(curso.Id_curso);
            var profesores = await APIUsuario.GetProfesoresByCursoAsync(curso.Id_curso);
            var materias = await APIMateria.GetAllAsync();
            var comisiones = await APIComision.GetAllAsync();
            
            var materia = materias.FirstOrDefault(m => m.Id_materia == curso.Id_materia);
            var comision = comisiones.FirstOrDefault(c => c.Id_comision == curso.Id_comision);
            
            var alumnosConNota = alumnos.Where(a => a.Nota.HasValue).ToList();
            var aprobados = alumnos.Where(a => a.Condicion == "Aprobado").Count();
            var reprobados = alumnos.Where(a => a.Condicion == "Reprobado").Count();
            var sinNota = alumnos.Where(a => !a.Nota.HasValue).Count();
            
            double promedio = alumnosConNota.Any() 
                ? alumnosConNota.Average(a => a.Nota!.Value) 
                : 0;
            
            int totalInscriptos = alumnos.Count;
            
            var distribucion = new Dictionary<string, int>
            {
                { "0-3", alumnosConNota.Count(a => a.Nota >= 0 && a.Nota <= 3) },
                { "4-6", alumnosConNota.Count(a => a.Nota >= 4 && a.Nota <= 6) },
                { "7-10", alumnosConNota.Count(a => a.Nota >= 7 && a.Nota <= 10) }
            };
            
            double totalConCondicion = aprobados + reprobados + sinNota;
            
            return new ReporteCursoDTO
            {
                IdCurso = curso.Id_curso,
                NombreMateria = materia?.Desc_materia ?? "Sin materia",
                DescripcionComision = comision?.Desc_comision ?? "Sin comisión",
                AnioCalendario = curso.Anio_calendario,
                CupoTotal = curso.Cupo,
                TotalInscriptos = totalInscriptos,
                PromedioGeneral = promedio,
                TotalAprobados = aprobados,
                TotalReprobados = reprobados,
                TotalSinNota = sinNota,
                Alumnos = alumnos,
                Profesores = profesores,
                DistribucionNotas = distribucion,
                PorcentajeAprobados = totalConCondicion > 0 ? (aprobados / totalConCondicion) * 100 : 0,
                PorcentajeReprobados = totalConCondicion > 0 ? (reprobados / totalConCondicion) * 100 : 0,
                PorcentajeSinNota = totalConCondicion > 0 ? (sinNota / totalConCondicion) * 100 : 0
            };
        }
    }
}
