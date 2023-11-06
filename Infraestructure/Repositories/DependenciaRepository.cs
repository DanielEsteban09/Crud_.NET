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
    public class DependenciaRepository : IDependenciaRepository
    {
        private readonly EjercicioContext _ejercicioContext;

        public DependenciaRepository(EjercicioContext ejercicioContext)
        {
            _ejercicioContext = ejercicioContext;
        }

        public async Task<IEnumerable<Respuesta>> ActualizarDependencia(DependenciumDTO dependencia)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ACTUALIZAR"),
                    new SqlParameter("@id", dependencia.Id),
                    new SqlParameter("@nombre_dependencia", dependencia.NombreDependencia)
                };

                string sql = "dbo.Sp_Dependencias @opc = @opc, @id = @id, @nombre_dependencia = @nombre_dependencia";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> EliminarDependencia(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@id", id)
                };

                string sql = "dbo.Sp_Dependencias @opc = @opc, @id = @id";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Dependencium>> ListarDependencias()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = "dbo.Sp_Dependencias @opc = @opc";
                var response = await _ejercicioContext.Dependencia.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> CrearDependencia(DependenciumDTO dependencia)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "CREAR"),
                    new SqlParameter("@nombre_dependencia", dependencia.NombreDependencia)
                };

                string sql = "dbo.Sp_Dependencias @opc = @opc, @nombre_dependencia = @nombre_dependencia";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }
    }
}