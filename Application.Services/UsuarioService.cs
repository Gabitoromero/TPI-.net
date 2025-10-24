using Data;
using Domain.Model;
using DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;
        private readonly PlanService _planService;

        private readonly CursoService _cursoService;
        private readonly InscripcionRepository _inscripcionRepository;

        public UsuarioService(UsuarioRepository usuarioRepository, PlanService planService, CursoService cursoService, InscripcionRepository inscripcionRepository)
        {
            _repository = usuarioRepository;
            _planService = planService;
            _cursoService = cursoService;
            _inscripcionRepository = inscripcionRepository;
        }

        public async Task<FullUsuarioDTO?> Get(int id)
        {

            Usuario? usuario = await _repository.Get(id);

            if (usuario == null) return null;


            FullUsuarioDTO dto = new FullUsuarioDTO
            {
                Id = usuario.Id,
                Apellido = usuario.Apellido,
                //Clave = usuario.ClaveHash, 
                Email = usuario.Email,
                Habilitado = usuario.Habilitado,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario,
                FechaAlta = usuario.FechaAlta,

                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                Tipo = usuario.Tipo,
                Legajo = usuario.Legajo,
                FechaNacimiento = usuario.FechaNacimiento,
                IdPlan = usuario.IdPlan,
            };

            return dto;
        }

        public async Task<ShowUsuarioDTO> GetByUsername(string nombreUsuario)
        {
            var user = await _repository.GetByUsername(nombreUsuario);

            ShowUsuarioDTO dto = new ShowUsuarioDTO
            {
                Id = user.Id,
                Email = user.Email,
                NombreUsuario = user.NombreUsuario
            };

            return dto;
        }
        public async Task<List<ShowUsuarioDTO>> GetAll()
        {
            List<Usuario> usuarios = await _repository.GetAll();

            return usuarios.Select(usuario => new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario
                , Tipo = usuario.Tipo
            }).ToList();
        }

        public async Task<List<ShowUsuarioDTO>> GetAllProfesores()
        {
            List<Usuario> usuarios = await _repository.GetAllProfesores();
            return usuarios.Select(usuario => new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario
                , Tipo = usuario.Tipo
            }).ToList();
        }
        public async Task<List<AlumnoCursoDetalleDTO>> GetAlumnosByCursoAsync(int idCurso)
        {
            var inscripciones = await _inscripcionRepository.GetAlumnosByCursoAsync(idCurso);

            return inscripciones.Select(item => new AlumnoCursoDetalleDTO
            {
                IdInscripcion = item.inscripcion.IdInscripcion,
                Legajo = item.alumno.Legajo,
                Alumno = $"{item.alumno.Nombre} {item.alumno.Apellido}",
                Condicion = item.inscripcion.Condicion,
                Nota = item.inscripcion.Nota
            }).ToList();
        }

        public async Task<List<ProfesorCursoDetalleDTO>> GetProfesoresByCursoAsync(int idCurso)
        {
            List<(Profesor_Curso dictado, Usuario profesor)> dictados = await _inscripcionRepository.GetProfesoresByCursoAsync(idCurso);

            return dictados.Select(item => new ProfesorCursoDetalleDTO
            {
                IdDictado = item.dictado.IdDictado,
                Legajo = item.profesor.Legajo,
                Nombre = $"{item.profesor.Nombre} {item.profesor.Apellido}",
                Cargo = item.dictado.Cargo
            }).ToList();
        }

        public async Task<List<ShowUsuarioDTO>> GetAllAlumnos()
        {
            List<Usuario> usuarios = await _repository.GetAllAlumnos();
            return usuarios.Select(usuario => new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario
                , Tipo = usuario.Tipo
            }).ToList();
        }
        public async Task<PostUsuarioDTO> Add(FullUsuarioDTO dto)
        {
            var plan = await _planService.Get(dto.IdPlan);

            if (plan == null)
            {
                throw new ArgumentException("El plan asociado no existe.");
            }

            var fechaCreacion = DateTime.Now;
            DateTime fechaNac = dto.FechaNacimiento;
            Usuario usuario = new Usuario(0, dto.Apellido, dto.Clave, dto.Email, true, dto.Nombre, dto.NombreUsuario, fechaCreacion,
                dto.Direccion, dto.Telefono, dto.Tipo, dto.Legajo, fechaNac, dto.IdPlan);

            await _repository.Add(usuario);

            return new PostUsuarioDTO
            {
                NombreUsuario = dto.NombreUsuario,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Clave = dto.Clave
            };

        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        private async Task<ShowUsuarioDTO?> GetReducedUser(int id)
        {

            Usuario? usuario = await _repository.Get(id);

            if (usuario == null) return null;


            ShowUsuarioDTO dto = new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario,
            };

            return dto;
        }


        public async Task<bool> Update(PutUsuarioDTO dto)
        {
            if (dto.IdPlan != null)
            {
                var plan = await _planService.Get(dto.IdPlan);

                if (plan == null)
                {
                    throw new ArgumentException("El plan asociado no existe.");
                }
            }

            Usuario? usuario = await _repository.Get(dto.Id);

            if (usuario == null) return false;

            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Email = dto.Email;
            usuario.Habilitado = dto.Habilitado;

            if (!string.IsNullOrWhiteSpace(dto.Clave)) usuario.SetClave(dto.Clave);

            return await _repository.Update(usuario);
        }

        // Inscripciones a cursos como profesor

        public async Task<List<ShowProfesor_CursoDTO>> GetAllProfesorInsc(int idProfesor)
        {
            var inscripciones = await _inscripcionRepository.GetAllProfesorInsc(idProfesor);
            var result = new List<ShowProfesor_CursoDTO>();
            foreach (var insc in inscripciones)
            {
                var curso = await _cursoService.Get(insc.IdCurso);
                var profesor = await GetReducedUser(insc.IdProfesor);
                result.Add(new ShowProfesor_CursoDTO
                {
                    IdDictado = insc.IdDictado,
                    Curso = curso,
                    Profesor = profesor,
                    Cargo = insc.Cargo
                });
            }
            return result;
        }

        public async Task<ShowProfesor_CursoDTO?> GetProfesorInsc(int idDictado)
        {
            var insc = await _inscripcionRepository.GetProfesorInsc(idDictado);

            if (insc == null) return null;

            var curso = await _cursoService.Get(insc.IdCurso);
            var profesor = await GetReducedUser(insc.IdProfesor);

            return new ShowProfesor_CursoDTO
            {
                IdDictado = insc.IdDictado,
                Curso = curso,
                Profesor = profesor,
                Cargo = insc.Cargo
            };
        }
        public async Task AddProfesorInsc(Profesor_CursoDTO dto)
        {
            NewCursoDTO curso = await _cursoService.Get(dto.IdCurso);
            Usuario profesor = await _repository.Get(dto.IdProfesor);

            if (curso == null)
            {
                throw new ArgumentException("Curso inexistente");
            }
            else if (profesor == null || profesor.Tipo != "profesor")
            {
                throw new ArgumentException("Profesor inexistente");
            }

            // Validar que el profesor no esté ya asignado al curso
            var profesoresDelCurso = await _inscripcionRepository.GetAllProfesorInsc(dto.IdProfesor);
            var yaAsignado = profesoresDelCurso.Any(p => p.IdCurso == dto.IdCurso);
            
            if (yaAsignado)
            {
                throw new ArgumentException("El profesor ya está asignado a este curso");
            }

            // Si es Titular, validar que no haya más de 3 Titulares
            if (dto.Cargo == "Titular")
            {
                var profesoresEnCurso = await _inscripcionRepository.GetProfesoresByCursoAsync(dto.IdCurso);
                int cantTitulares = profesoresEnCurso.Count(p => p.dictado.Cargo == "Titular");
                
                if (cantTitulares >= 3)
                {
                    throw new ArgumentException("El curso ya tiene el máximo de 3 profesores Titulares");
                }
            }

            var profesorInsc = new Profesor_Curso
            {
                IdDictado = 0,
                IdProfesor = profesor.Id,
                IdCurso = dto.IdCurso,
                Cargo = dto.Cargo
            };
            await _inscripcionRepository.AddProfesorInsc(profesorInsc);
        }

        public async Task DeleteProfesorInsc(int idDictado)
        {
            await _inscripcionRepository.DeleteProfesorInsc(idDictado);
        }

        public async Task UpdateProfesorInsc(Profesor_CursoDTO dto)
        {
            var curso = await _cursoService.Get(dto.IdCurso);
            var profesor = await Get(dto.IdProfesor);
            if (curso == null)
            {
                throw new ArgumentException("Curso inexistente");
            }
            else if (profesor == null || profesor.Tipo != "profesor")
            {
                throw new ArgumentException("Profesor inexistente");
            }
            var profesorInsc = new Profesor_Curso
            {
                IdDictado = dto.IdDictado,
                IdProfesor = dto.IdProfesor,
                IdCurso = dto.IdCurso,
                Cargo = dto.Cargo
            };
            await _inscripcionRepository.UpdateProfesorInsc(profesorInsc);
        }

        // Inscripciones a cursos como alumno

        public async Task<List<ShowAlumno_CursoDTO>> GetAllAlumnoInsc(int idAlumno)
        {
            var inscripciones = await _inscripcionRepository.GetAllAlumnoInsc(idAlumno);
            var result = new List<ShowAlumno_CursoDTO>();
            foreach (var insc in inscripciones)
            {
                var curso = await _cursoService.Get(insc.IdCurso);
                var alumno = await GetReducedUser(insc.IdAlumno);
                result.Add(new ShowAlumno_CursoDTO
                {
                    IdInscripcion = insc.IdInscripcion,
                    Curso = curso,
                    Alumno = alumno,
                    Condicion = insc.Condicion,
                    Nota = insc.Nota
                });
            }
            return result;
        }

        public async Task AddAlumnoInsc(Alumno_CursoDTO dto)
        {
            var curso = await _cursoService.Get(dto.IdCurso);
            var alumno = await Get(dto.IdAlumno);
            if (curso == null)
            {
                throw new ArgumentException("Curso inexistente");
            }
            else if (alumno == null)
            {
                throw new ArgumentException("Alumno inexistente");
            }
            else if (alumno.Tipo != "alumno")
            {
                throw new ArgumentException("El usuario no es un alumno");
            }
            else if (!alumno.Habilitado)
            {
                throw new ArgumentException("El alumno no está habilitado");
            }

            int cantInsc = await _inscripcionRepository.GetAlumnoCountInCurso(dto.IdCurso);
            if (cantInsc >= curso.Cupo)
            {
                throw new ArgumentException("El curso está lleno");
            }

            var alumnoInsc = new Alumno_Curso
            {
                IdInscripcion = 0,
                IdAlumno = dto.IdAlumno,
                IdCurso = dto.IdCurso,
                Condicion = dto.Condicion,
                Nota = dto.Nota
            };
            await _inscripcionRepository.AddAlumnoInsc(alumnoInsc);
        }

        public async Task DeleteAlumnoInsc(int idInscripcion)
        {
            await _inscripcionRepository.DeleteAlumnoInsc(idInscripcion);
        }

        public async Task UpdateAlumnoInsc(Alumno_CursoDTO dto)
        {
            var curso = await _cursoService.Get(dto.IdCurso);
            var alumno = await Get(dto.IdAlumno);
            if (curso == null)
            {
                throw new ArgumentException("Curso inexistente");
            }
            else if (alumno == null)
            {
                throw new ArgumentException("Alumno inexistente");
            }
            else if (alumno.Tipo != "alumno")
            {
                throw new ArgumentException("El usuario no es un alumno");
            }
            var alumnoInsc = new Alumno_Curso
            {
                IdInscripcion = dto.IdInscripcion,
                IdAlumno = dto.IdAlumno,
                IdCurso = dto.IdCurso,
                Condicion = dto.Condicion,
                Nota = dto.Nota
            };
            await _inscripcionRepository.UpdateAlumnoInsc(alumnoInsc);
        }

        
    }
}
