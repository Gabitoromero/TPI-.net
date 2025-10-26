using Data;
using DTOs;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MateriaService
    {
        private readonly MateriaRepository _repository;
        private readonly CursoRepository _cursoRepository;
        
        public MateriaService(MateriaRepository repo, CursoRepository repoCurso)
        {
            _repository = repo;
            _cursoRepository = repoCurso;
        }

        public async Task<MateriaDTO?> Get(int id)
        {
            Materia m = await _repository.Get(id);
            if (m == null) return null;
            return new MateriaDTO
            {
                Id_materia = m.Id_materia,
                Desc_materia = m.Desc_materia,
                Hs_semanales = m.Hs_semanales,
                Hs_totales = m.Hs_totales,
                Id_plan = m.Id_plan,
                Habilitado = m.Habilitado
            };
        }

        public async Task<List<MateriaDTO>> GetAll()
        {
            return (await _repository.GetAll()).Select(m => new MateriaDTO
            {
                Id_materia = m.Id_materia,
                Desc_materia = m.Desc_materia,
                Hs_semanales = m.Hs_semanales,
                Hs_totales = m.Hs_totales,
                Id_plan = m.Id_plan,
                Habilitado = m.Habilitado
            }).ToList();
        }

        public async Task<MateriaDTO> Add(MateriaDTO dto)
        {
            Materia m = new Materia
            {
                Id_materia = 0,
                Desc_materia = dto.Desc_materia,
                Hs_semanales = dto.Hs_semanales,
                Hs_totales = dto.Hs_totales,
                Id_plan = dto.Id_plan,
                Habilitado = true
            };
            await _repository.Add(m);
            dto.Id_materia = m.Id_materia;
            return dto;
        }

        public async Task<bool> Update(MateriaDTO dto)
        {
            try
            {
                // Obtener la materia actual de la base de datos
                Materia? materiaActual = await _repository.Get(dto.Id_materia);
                
                if (materiaActual == null)
                {
                    return false;
                }

                // Verificar si se está reactivando la materia (de deshabilitada a habilitada)
                bool seEstaReactivando = !materiaActual.Habilitado && dto.Habilitado;

                if (seEstaReactivando)
                {
                    // Obtener todos los cursos asociados a esta materia
                    List<Curso> cursos = await _cursoRepository.GetAll();
                    List<Curso> cursosMateria = cursos.Where(c => c.Id_materia == dto.Id_materia).ToList();
                    
                    // Reactivar todos los cursos de esta materia
                    foreach (Curso curso in cursosMateria)
                    {
                        curso.Habilitado = true;
                        await _cursoRepository.Update(curso);
                    }
                }

                // Actualizar la materia
                Materia m = new Materia
                {
                    Id_materia = dto.Id_materia,
                    Desc_materia = dto.Desc_materia,
                    Hs_semanales = dto.Hs_semanales,
                    Hs_totales = dto.Hs_totales,
                    Id_plan = dto.Id_plan,
                    Habilitado = dto.Habilitado
                };
                return await _repository.Update(m);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            // Obtener todos los cursos asociados a esta materia
            List<Curso> cursos = await _cursoRepository.GetAll();
            List<Curso> cursosMateria = cursos.Where(c => c.Id_materia == id).ToList();
            
            // Dar de baja lógicamente todos los cursos de esta materia
            foreach (Curso curso in cursosMateria)
            {
                await _cursoRepository.Delete(curso.Id_curso);
            }
            
            // Dar de baja lógicamente la materia
            return await _repository.Delete(id);
        }
    }
}
