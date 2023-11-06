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
    public class PersonaService : IPersonaService
    {
        private IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public Task<IEnumerable<Respuesta>> ActualizarPersona(PersonaDTO persona)
        {
            var ActualizarPersona = _personaRepository.ActualizarPersona(persona);
            return ActualizarPersona;
        }

        public Task<IEnumerable<Respuesta>> AgregarPersona(PersonaDTO persona)
        {
            var createPersona = _personaRepository.AgregarPersona(persona);
            return createPersona;
        }

        public Task<IEnumerable<Respuesta>> EliminarPersona(int id)
        {
            var EliminarPersona = _personaRepository.EliminarPersona(id);
            return EliminarPersona;
        }

        public Task<IEnumerable<Persona>> ListarPersona()
        {
            var listPersonas = _personaRepository.ListarPersonas();
            return listPersonas;
        }
    }
}
