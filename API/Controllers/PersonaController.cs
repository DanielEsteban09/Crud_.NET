using API.Responses;
using AutoMapper;
using Core.Data;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaServices;
        private readonly IMapper _mapper;


        public PersonaController(IPersonaService personaServices, IMapper mapper)
        {
            _personaServices = personaServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListPersonas ()
        {
            var response = await _personaServices.ListarPersona();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(PersonaDTO personas)
        {
            var persona = await _personaServices.AgregarPersona(personas);
            var personasDto = _mapper.Map<IEnumerable<Respuesta>>(persona);
            var response = new ApiResponse<IEnumerable<Respuesta>>(personasDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar(PersonaDTO personas)
        {
            var persona = await _personaServices.ActualizarPersona(personas);
            var personaDto = _mapper.Map<IEnumerable<Respuesta>>(persona);
            var response = new ApiResponse<IEnumerable<Respuesta>>(personaDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var persona = await _personaServices.EliminarPersona(id);
            var personaDto = _mapper.Map<IEnumerable<Respuesta>>(persona);
            var response = new ApiResponse<IEnumerable<Respuesta>>(personaDto);
            return Ok(response);
        }
    }
}
