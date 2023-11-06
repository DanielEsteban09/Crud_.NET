using Core.Data;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDependenciaServices
    {
        Task<IEnumerable<Dependencium>> ListarDependencias();
        Task<IEnumerable<Respuesta>> CrearDependencia(DependenciumDTO dependencia);
        Task<IEnumerable<Respuesta>> ActualizarDependencia(DependenciumDTO dependencia);
        Task<IEnumerable<Respuesta>> EliminarDependencia(int id);
    }
}
