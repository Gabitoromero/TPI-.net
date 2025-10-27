using DTOs;
using API.Clients;

namespace BlazorApp.Services
{
    public class ReportePlanAlumnoService
    {
        public static async Task<ReportePlanAlumnoDTO> ObtenerDatosReporteAsync(int idAlumno)
        {
            var alumno = await APIUsuario.GetAsync(idAlumno);
            var plan = await APIPlan.GetAsync(alumno.IdPlan);
            var especialidad = await APIEspecialidad.GetAsync(plan.IdEspecialidad);
            
            var todasLasMaterias = await APIMateria.GetAllAsync();
            var materiasDelPlan = todasLasMaterias.Where(m => m.Id_plan == alumno.IdPlan).ToList();
            
            var inscripciones = await APIUsuario.GetAlumnoCursosAsync(idAlumno);
            
            var estadoMaterias = new Dictionary<int, string>();
            
            foreach (var inscripcion in inscripciones)
            {
                int idMateria = inscripcion.Curso.Id_materia;
                string condicion = inscripcion.Condicion ?? string.Empty;
                
                if (estadoMaterias.ContainsKey(idMateria))
                {
                    var condicionActual = estadoMaterias[idMateria];
                    
                    if (condicionActual == "Aprobado")
                        continue;
                    
                    if (condicionActual == "Cursando" && condicion == "Aprobado")
                        estadoMaterias[idMateria] = condicion;
                    
                    if (condicionActual == "Reprobado" && (condicion == "Aprobado" || condicion == "Cursando"))
                        estadoMaterias[idMateria] = condicion;
                }
                else
                {
                    estadoMaterias[idMateria] = condicion;
                }
            }
            
            var materias = new List<MateriaPlanAlumnoDTO>();
            int aprobadas = 0;
            
            foreach (var materia in materiasDelPlan.OrderBy(m => m.Desc_materia))
            {
                string condicion = string.Empty;
                
                if (estadoMaterias.ContainsKey(materia.Id_materia))
                {
                    condicion = estadoMaterias[materia.Id_materia];
                }
                
                var materiaDto = new MateriaPlanAlumnoDTO
                {
                    NombreMateria = materia.Desc_materia,
                    HorasSemanales = materia.Hs_semanales,
                    Condicion = condicion
                };
                
                materias.Add(materiaDto);
                
                if (condicion == "Aprobado")
                {
                    aprobadas++;
                }
            }
            
            return new ReportePlanAlumnoDTO
            {
                Legajo = alumno.Legajo,
                NombreCompleto = $"{alumno.Nombre} {alumno.Apellido}",
                NombrePlan = plan.Descripcion,
                NombreEspecialidad = especialidad.Descripcion,
                TotalMateriasPlan = materiasDelPlan.Count,
                MateriasAprobadas = aprobadas,
                Materias = materias
            };
        }
    }
}
