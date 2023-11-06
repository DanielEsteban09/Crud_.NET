using Core.Data;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class DependenciaServices : IDependenciaServices
    {
        private IDependenciaRepository _dependenciaRepository;

        public DependenciaServices(IDependenciaRepository dependenciaRepository)
        {
            _dependenciaRepository = dependenciaRepository;
        }

        public Task<IEnumerable<Respuesta>> ActualizarDependencia(DependenciumDTO dependencia)
        {
            var actualizarDependencia = _dependenciaRepository.ActualizarDependencia(dependencia);
            return actualizarDependencia;
        }

        public Task<IEnumerable<Respuesta>> CrearDependencia(DependenciumDTO dependencia)
        {
            var createDependencia = _dependenciaRepository.CrearDependencia(dependencia);
            return createDependencia;
        }

        public Task<IEnumerable<Respuesta>> EliminarDependencia(int id)
        {
            var eliminarDependencia = _dependenciaRepository.EliminarDependencia(id);
            return eliminarDependencia;
        }

        public Task<IEnumerable<Dependencium>> ListarDependencias()
        {
            var listDependencias = _dependenciaRepository.ListarDependencias();
            return listDependencias;
        }
    }
}
