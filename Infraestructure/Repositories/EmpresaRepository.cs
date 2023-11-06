using Core.Data;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Infraestructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly EjercicioContext _ejercicioContext;

        public EmpresaRepository(EjercicioContext ejercicioContext)
        {
            _ejercicioContext = ejercicioContext;
        }
        public async Task<IEnumerable<Respuesta>> ActualizarEmpresas(EmpresaDTO empresas)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ACTUALIZAR"),
                    new SqlParameter("@id", empresas.Id),
                    new SqlParameter("@nombre_empresa", empresas.NombreEmpresa),
                    new SqlParameter("@direccion_empresa", empresas.DireccionEmpresa)
                };

                string sql = $"dbo.Sp_Empresa @opc = @opc, @id = @id, @nombre_empresa = @nombre_empresa, @direccion_empresa = @direccion_empresa";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> CrearEmpresa(EmpresaDTO empresas)
        {
            try 
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "CREAR"),
                    new SqlParameter("@nombre_empresa", empresas.NombreEmpresa),
                    new SqlParameter("@direccion_empresa", empresas.DireccionEmpresa)
                };

                string sql = $"dbo.Sp_Empresa @opc = @opc, @nombre_empresa = @nombre_empresa, @direccion_empresa = @direccion_empresa";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }

        }

        public async Task<IEnumerable<Respuesta>> EliminarEmpresas(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@id", id)
                };

                string sql = $"dbo.Sp_Empresa @opc = @opc, @id = @id";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Empresa>> ListarEmpresas()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"dbo.Sp_Empresa @opc = @opc";
                var response = await _ejercicioContext.Empresas.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }
    }
}
