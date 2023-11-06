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
    public  interface IEmpresaServices
    {
        Task<IEnumerable<Empresa>> ListarEmpresas();

        Task<IEnumerable<Respuesta>> CrearEmpresa(EmpresaDTO empresas);

        Task<IEnumerable<Respuesta>> ActualizarEmpresas(EmpresaDTO empresas);

        Task<IEnumerable<Respuesta>> EliminarEmpresas(int id);
    }
}
