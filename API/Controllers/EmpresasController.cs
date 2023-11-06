using API.Responses;
using AutoMapper;
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
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaServices _empresaServices;
        private readonly IMapper _mapper;


       public EmpresasController(IEmpresaServices empresaServices, IMapper mapper)
        {
            _empresaServices = empresaServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListEmpresas ()
        {
            var response = await _empresaServices.ListarEmpresas();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EmpresaDTO empresas)
        {
            var empresa = await _empresaServices.CrearEmpresa(empresas);
            var usuariossDto = _mapper.Map<IEnumerable<Respuesta>>(empresa);
            var response = new ApiResponse<IEnumerable<Respuesta>>(usuariossDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar(EmpresaDTO empresas)
        {
            var empresa = await _empresaServices.ActualizarEmpresas(empresas);
            var usuariossDto = _mapper.Map<IEnumerable<Respuesta>>(empresa);
            var response = new ApiResponse<IEnumerable<Respuesta>>(usuariossDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var empresa = await _empresaServices.EliminarEmpresas(id);
            var usuariossDto = _mapper.Map<IEnumerable<Respuesta>>(empresa);
            var response = new ApiResponse<IEnumerable<Respuesta>>(usuariossDto);
            return Ok(response);
        }

    }
}
