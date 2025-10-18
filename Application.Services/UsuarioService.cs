using Data;
using Domain.Model;
using DTOs;

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

        public FullUsuarioDTO? Get(int id)
        {

            Usuario? usuario = _repository.Get(id);

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
        public List<ShowUsuarioDTO> GetAll()
        {
            List<Usuario> usuarios = _repository.GetAll();

            return usuarios.Select(usuario => new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario
            }).ToList();
        }
        public PostUsuarioDTO Add(FullUsuarioDTO dto)
        {
            var plan = _planService.Get(dto.IdPlan);

            if (plan == null)
            {
                throw new ArgumentException("El plan asociado no existe.");
            }

            var fechaCreacion = DateTime.Now;
            Usuario usuario = new Usuario(0, dto.Apellido, dto.Clave, dto.Email, true, dto.Nombre, dto.NombreUsuario, fechaCreacion,
                dto.Direccion, dto.Telefono, dto.Tipo, dto.Legajo, dto.FechaNacimiento, dto.IdPlan);

            _repository.Add(usuario);

            return new PostUsuarioDTO
            {
                NombreUsuario = dto.NombreUsuario,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Clave = dto.Clave
            };

        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        private ShowUsuarioDTO? GetReducedUser(int id)
        {

            Usuario? usuario = _repository.Get(id);

            if (usuario == null) return null;


            ShowUsuarioDTO dto = new ShowUsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.NombreUsuario,
            };

            return dto;
        }


        public bool Update(PutUsuarioDTO dto)
        {
            if (dto.IdPlan != null)
            {
                var plan = _planService.Get(dto.IdPlan);

                if (plan == null)
                {
                    throw new ArgumentException("El plan asociado no existe.");
                }
            }

            Usuario? usuario = _repository.Get(dto.Id);

            if (usuario == null) return false;

            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Email = dto.Email;
            usuario.Habilitado = dto.Habilitado;

            if (!string.IsNullOrWhiteSpace(dto.Clave)) usuario.SetClave(dto.Clave);

            return _repository.Update(usuario);
        }

        // Inscripciones a cursos como profesor

        public List<ShowProfesor_CursoDTO> GetAllProfesorInsc(int idProfesor)
        {
            var inscripciones = _inscripcionRepository.GetAllProfesorInsc(idProfesor);
            return inscripciones.Select(insc => new ShowProfesor_CursoDTO
            {
                IdDictado = insc.IdDictado,
                Curso = _cursoService.Get(insc.IdDictado),
                Profesor = this.GetReducedUser(insc.IdProfesor),
                Cargo = insc.Cargo
            }).ToList();
        }

        public ShowProfesor_CursoDTO? GetProfesorInsc(int idDictado)
        {
            var insc = _inscripcionRepository.GetProfesorInsc(idDictado);

            if (insc == null) return null;

            return new ShowProfesor_CursoDTO
            {
                IdDictado = insc.IdDictado,
                Curso = _cursoService.Get(insc.IdDictado),
                Profesor = this.GetReducedUser(insc.IdProfesor),
                Cargo = insc.Cargo
            };
        }
        public void AddProfesorInsc(Profesor_CursoDTO dto)
        {
            var curso = _cursoService.Get(dto.IdCurso);
            var profesor = this.Get(dto.IdProfesor);

            if (curso == null)
            {
                throw new ArgumentException("Curso inexistente");
            }
            else if (profesor == null)
            {
                throw new ArgumentException("Profesor inexistente");
            }

            var profesorInsc = new Profesor_Curso
            {
                IdDictado = 0,
                IdProfesor = dto.IdProfesor,
                IdCurso = dto.IdCurso,
                Cargo = dto.Cargo
            };
            _inscripcionRepository.AddProfesorInsc(profesorInsc);
        }

        public void DeleteProfesorInsc(int idDictado)
        {
            _inscripcionRepository.DeleteProfesorInsc(idDictado);
        }

        public void UpdateProfesorInsc(Profesor_CursoDTO dto)
        {
            var curso = _cursoService.Get(dto.IdDictado);
            var profesor = this.Get(dto.IdProfesor);
            if (curso == null)
            {
                throw new ArgumentException("Curso inexistente");
            }
            else if (profesor == null)
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
            _inscripcionRepository.UpdateProfesorInsc(profesorInsc);
        }
    }
}
