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
    public interface IPersonaRepository
    {
        Task<IEnumerable<Respuesta>> AgregarPersona(PersonaDTO persona);
        Task<IEnumerable<Persona>> ListarPersonas();

        Task<IEnumerable<Respuesta>> ActualizarPersona(PersonaDTO persona);
        Task<IEnumerable<Respuesta>> EliminarPersona(int id);
    }
}
