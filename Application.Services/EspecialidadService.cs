using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class EspecialidadService
    {
        private readonly PlanRepository _planRepository;
        private readonly EspecialidadRepository _repository;
        private readonly ComisionRepository _comisionRepository;
        private readonly MateriaRepository _materiaRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly CursoRepository _cursoRepository;

        public EspecialidadService(EspecialidadRepository especialidadRepository, PlanRepository planRepository, 
                                   ComisionRepository comisionRepository, MateriaRepository materiaRepository,
                                   UsuarioRepository usuarioRepository, CursoRepository cursoRepository)
        {
            _repository = especialidadRepository;
            _planRepository = planRepository;
            _comisionRepository = comisionRepository;
            _materiaRepository = materiaRepository;
            _usuarioRepository = usuarioRepository;
            _cursoRepository = cursoRepository;
        }
        
        public async Task<EspecialidadDTO?> Get(int id)
        {
            var esp = await _repository.Get(id);
            if (esp == null) return null;
  
            return new EspecialidadDTO 
            { 
                Id = esp.Id, 
                Descripcion = esp.Descripcion,
                Habilitado = esp.Habilitado
            };
        } 
        
        public async Task<List<EspecialidadDTO>> GetAll()
        {
            List<Especialidad> especialidades = await _repository.GetAll();
            return especialidades.Select(e => new EspecialidadDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion,
                Habilitado = e.Habilitado
            }).ToList();
        }
        
        public async Task<EspecialidadDTO> Add(EspecialidadDTO dto)
        {   
            Especialidad esp = new Especialidad(0, dto.Descripcion);
            esp.Habilitado = true;
            await _repository.Add(esp);
            dto.Id = esp.Id;
            return dto;
        }

        public async Task<bool> Update(EspecialidadDTO dto)
        {
            try
            {
                // Obtener la especialidad actual
                Especialidad? especialidadActual = await _repository.Get(dto.Id);
                if (especialidadActual == null) return false;

                // Verificar si se está reactivando
                bool seEstaReactivando = !especialidadActual.Habilitado && dto.Habilitado;

                if (seEstaReactivando)
                {
                    // Obtener planes de esta especialidad
                    List<Plan> planes = await _planRepository.GetAll();
                    List<Plan> planesEsp = planes.Where(p => p.IdEspecialidad == dto.Id).ToList();
                    
                    foreach (Plan plan in planesEsp)
                    {
                        // Reactivar USUARIOS del plan
                        List<Usuario> usuarios = await _usuarioRepository.GetAll();
                        List<Usuario> usuariosPlan = usuarios.Where(u => u.IdPlan == plan.IdPlan).ToList();
                        foreach (Usuario usuario in usuariosPlan)
                        {
                            usuario.Habilitado = true;
                            await _usuarioRepository.Update(usuario);
                        }

                        // Obtener comisiones y materias del plan
                        List<Comision> todasComisiones = await _comisionRepository.GetAll();
                        List<Comision> comisionesPlan = todasComisiones.Where(c => c.Id_plan == plan.IdPlan).ToList();
                        
                        List<Materia> todasMaterias = await _materiaRepository.GetAll();
                        List<Materia> materiasPlan = todasMaterias.Where(m => m.Id_plan == plan.IdPlan).ToList();
                        
                        // Obtener IDs para filtrar cursos
                        HashSet<int> idsComisionesPlan = comisionesPlan.Select(c => c.Id_comision).ToHashSet();
                        HashSet<int> idsMateriasPlan = materiasPlan.Select(m => m.Id_materia).ToHashSet();

                        // Obtener todos los cursos
                        List<Curso> todosCursos = await _cursoRepository.GetAll();
                        
                        // Reactivar SOLO cursos que tienen TANTO comisión COMO materia del plan
                        List<Curso> cursosPlan = todosCursos
                            .Where(c => idsComisionesPlan.Contains(c.Id_comision) && idsMateriasPlan.Contains(c.Id_materia))
                            .ToList();
                        
                        foreach (Curso curso in cursosPlan)
                        {
                            curso.Habilitado = true;
                            await _cursoRepository.Update(curso);
                        }

                        // Reactivar COMISIONES del plan
                        foreach (Comision comision in comisionesPlan)
                        {
                            comision.Habilitado = true;
                            await _comisionRepository.Update(comision);
                        }

                        // Reactivar MATERIAS del plan
                        foreach (Materia materia in materiasPlan)
                        {
                            materia.Habilitado = true;
                            await _materiaRepository.Update(materia);
                        }

                        // Reactivar el PLAN
                        plan.Habilitado = true;
                        await _planRepository.Update(plan);
                    }
                }

                // Actualizar la especialidad
                Especialidad esp = new Especialidad(dto.Id, dto.Descripcion);
                esp.Habilitado = dto.Habilitado;
                return await _repository.Update(esp);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id) 
        {
            try
            {
                // Obtener planes de esta especialidad
                List<Plan> planes = await _planRepository.GetAll();
                List<Plan> planesEsp = planes.Where(p => p.IdEspecialidad == id).ToList();
                
                foreach (Plan plan in planesEsp)
                {
                    // Deshabilitar USUARIOS del plan
                    List<Usuario> usuarios = await _usuarioRepository.GetAll();
                    List<Usuario> usuariosPlan = usuarios.Where(u => u.IdPlan == plan.IdPlan).ToList();
                    foreach (Usuario usuario in usuariosPlan)
                    {
                        await _usuarioRepository.Delete(usuario.Id);
                    }

                    // Obtener comisiones y materias del plan
                    List<Comision> todasComisiones = await _comisionRepository.GetAll();
                    List<Comision> comisionesPlan = todasComisiones.Where(c => c.Id_plan == plan.IdPlan).ToList();
                    
                    List<Materia> todasMaterias = await _materiaRepository.GetAll();
                    List<Materia> materiasPlan = todasMaterias.Where(m => m.Id_plan == plan.IdPlan).ToList();
                    
                    // Obtener IDs para filtrar cursos eficientemente
                    HashSet<int> idsComisionesPlan = comisionesPlan.Select(c => c.Id_comision).ToHashSet();
                    HashSet<int> idsMateriasPlan = materiasPlan.Select(m => m.Id_materia).ToHashSet();

                    // Obtener todos los cursos
                    List<Curso> todosCursos = await _cursoRepository.GetAll();
                    
                    // Deshabilitar SOLO cursos que tienen TANTO comisión COMO materia del plan
                    List<Curso> cursosPlan = todosCursos
                        .Where(c => idsComisionesPlan.Contains(c.Id_comision) && idsMateriasPlan.Contains(c.Id_materia))
                        .ToList();
                    
                    foreach (Curso curso in cursosPlan)
                    {
                        await _cursoRepository.Delete(curso.Id_curso);
                    }

                    // Deshabilitar COMISIONES del plan
                    foreach (Comision comision in comisionesPlan)
                    {
                        await _comisionRepository.Delete(comision.Id_comision);
                    }

                    // Deshabilitar MATERIAS del plan
                    foreach (Materia materia in materiasPlan)
                    {
                        await _materiaRepository.Delete(materia.Id_materia);
                    }

                    // Deshabilitar el PLAN
                    await _planRepository.Delete(plan.IdPlan);
                }

                // Deshabilitar la ESPECIALIDAD
                return await _repository.Delete(id);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
