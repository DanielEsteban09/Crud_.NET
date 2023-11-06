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
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> ListarPersona();

        Task<IEnumerable<Respuesta>> AgregarPersona(PersonaDTO persona);

        Task<IEnumerable<Respuesta>> ActualizarPersona(PersonaDTO persona);

        Task<IEnumerable<Respuesta>> EliminarPersona(int id);
    }
}
