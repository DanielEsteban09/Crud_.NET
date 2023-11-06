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
    public class DependenciaController : ControllerBase
    {
        private readonly IDependenciaServices _dependenciaServices;
        private readonly IMapper _mapper;

        public DependenciaController(IDependenciaServices dependenciaServices, IMapper mapper)
        {
            _dependenciaServices = dependenciaServices;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> ListDependencias ()
        {
            var response = await _dependenciaServices.ListarDependencias();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(DependenciumDTO dependencia)
        {
            var dependencias = await _dependenciaServices.CrearDependencia(dependencia);
            var dependenciasDto = _mapper.Map<IEnumerable<Respuesta>>(dependencias);
            var response = new ApiResponse<IEnumerable<Respuesta>>(dependenciasDto);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar(DependenciumDTO dependencias)
        {
            var dependencia = await _dependenciaServices.ActualizarDependencia(dependencias);
            var dependenciaDto = _mapper.Map<IEnumerable<Respuesta>>(dependencia);
            var response = new ApiResponse<IEnumerable<Respuesta>>(dependenciaDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var dependencia = await _dependenciaServices.EliminarDependencia(id);
            var dependenciaDto = _mapper.Map<IEnumerable<Respuesta>>(dependencia);
            var response = new ApiResponse<IEnumerable<Respuesta>>(dependenciaDto);
            return Ok(response);
        }
    }
}
