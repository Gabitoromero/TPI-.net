using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Data;
using Domain.Model;
using System.Data;

namespace Application.Services
{
    public class PlanService
    {
        private readonly PlanRepository _repository;
        private readonly MateriaRepository _materiaRepository;
        private readonly ComisionRepository _comisionRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly CursoRepository _cursoRepository;

        public PlanService(PlanRepository planRepository, MateriaRepository materiaRepository, ComisionRepository comisionRepository, UsuarioRepository usuarioRepository, CursoRepository cursoRepository)
        {
            _repository = planRepository;
            _materiaRepository = materiaRepository;
            _comisionRepository = comisionRepository;
            _usuarioRepository = usuarioRepository;
            _cursoRepository = cursoRepository;
        }
        
        public async Task<List<PlanDTO>> GetAll()
        {
            List<Plan> planes = await _repository.GetAll();
            return planes.Select(p => new PlanDTO 
            { 
                IdPlan = p.IdPlan, 
                Descripcion = p.Descripcion, 
                IdEspecialidad = p.IdEspecialidad,
                Habilitado = p.Habilitado
            }).ToList();
        }

        public async Task<PlanDTO> Get(int id)
        {
            Plan plan = await _repository.Get(id);
            if (plan == null)
            {
                return null;
            }

            return new PlanDTO 
            { 
                IdPlan = plan.IdPlan, 
                Descripcion = plan.Descripcion, 
                IdEspecialidad = plan.IdEspecialidad,
                Habilitado = plan.Habilitado
            };
        }

        public async Task<PlanDTO> Add(PlanDTO dto)
        {
            try
            {
                Plan newplan = new Plan(0, dto.Descripcion, dto.IdEspecialidad);
                newplan.Habilitado = true;
                await _repository.Add(newplan);
                dto.IdPlan = newplan.IdPlan;
                return dto;
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Update(PlanDTO dto)
        {
            try
            {
                // Obtener el plan actual de la base de datos
                Plan? planActual = await _repository.Get(dto.IdPlan);
                
                if (planActual == null)
                {
                    return false;
                }

                // Verificar si se está reactivando el plan (de deshabilitado a habilitado)
                bool seEstaReactivando = !planActual.Habilitado && dto.Habilitado;

                if (seEstaReactivando)
                {
                    // Reactivar USUARIOS del plan
                    List<Usuario> usuarios = await _usuarioRepository.GetAll();
                    List<Usuario> usuariosPlan = usuarios.Where(u => u.IdPlan == dto.IdPlan).ToList();
                    
                    foreach (Usuario usuario in usuariosPlan)
                    {
                        usuario.Habilitado = true;
                        await _usuarioRepository.Update(usuario);
                    }

                    // Obtener comisiones y materias del plan
                    List<Comision> todasComisiones = await _comisionRepository.GetAll();
                    List<Comision> comisionesPlan = todasComisiones.Where(c => c.Id_plan == dto.IdPlan).ToList();
                    
                    List<Materia> todasMaterias = await _materiaRepository.GetAll();
                    List<Materia> materiasPlan = todasMaterias.Where(m => m.Id_plan == dto.IdPlan).ToList();
                    
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
                }

                // Actualizar el plan
                Plan planToUpdate = new Plan(dto.IdPlan, dto.Descripcion, dto.IdEspecialidad);
                planToUpdate.Habilitado = dto.Habilitado;
                return await _repository.Update(planToUpdate);
            }
            catch(ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                // Deshabilitar USUARIOS del plan
                List<Usuario> usuarios = await _usuarioRepository.GetAll();
                List<Usuario> usuariosPlan = usuarios.Where(u => u.IdPlan == id).ToList();
                
                foreach (Usuario usuario in usuariosPlan)
                {
                    await _usuarioRepository.Delete(usuario.Id);
                }

                // Obtener comisiones y materias del plan
                List<Comision> todasComisiones = await _comisionRepository.GetAll();
                List<Comision> comisionesPlan = todasComisiones.Where(c => c.Id_plan == id).ToList();
                
                List<Materia> todasMaterias = await _materiaRepository.GetAll();
                List<Materia> materiasPlan = todasMaterias.Where(m => m.Id_plan == id).ToList();
                
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

                // Deshabilitar el plan
                return await _repository.Delete(id);
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
