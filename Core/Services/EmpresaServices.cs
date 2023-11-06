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
    public class EmpresaServices : IEmpresaServices
    {
        private IEmpresaRepository _empresaRepository;
        
        public EmpresaServices(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Task<IEnumerable<Respuesta>> CrearEmpresa(EmpresaDTO empresas)
        {
            var createEmpresa = _empresaRepository.CrearEmpresa(empresas);
            return createEmpresa;
        }

        public Task<IEnumerable<Empresa>> ListarEmpresas()
        {
            var listEmpresas = _empresaRepository.ListarEmpresas();

            return listEmpresas;
        }

        public Task<IEnumerable<Respuesta>> ActualizarEmpresas(EmpresaDTO empresas)
        {
            var ActualizarEmpresa = _empresaRepository.ActualizarEmpresas(empresas);
            return ActualizarEmpresa;
        }

        public Task<IEnumerable<Respuesta>> EliminarEmpresas(int id)
        {
            var ActualizarEmpresa = _empresaRepository.EliminarEmpresas(id);
            return ActualizarEmpresa;
        }
    }
}
