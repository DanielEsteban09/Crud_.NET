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
    public class PersonasRepository : IPersonaRepository
    {
        private readonly EjercicioContext _ejercicioContext;

        public PersonasRepository(EjercicioContext ejercicioContext)
        {
            _ejercicioContext = ejercicioContext;
        }

        public async Task<IEnumerable<Respuesta>> ActualizarPersona(PersonaDTO persona)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ACTUALIZAR"),
                    new SqlParameter("@id", persona.Id),
                    new SqlParameter("@nombre", persona.Nombre),
                    new SqlParameter("@apellido", persona.Apellido),
                    new SqlParameter("@identificacion", persona.Identificacion),
                    new SqlParameter("@tipo_identificacion", persona.TipoIdentificacion),
                    new SqlParameter("@sexo", persona.Sexo)
                };

                string sql = $"dbo.Sp_Personas @opc = @opc, @id = @id, @nombre = @nombre, @apellido = @apellido, @identificacion = @identificacion, @tipo_identificacion = @tipo_identificacion, @sexo = @sexo";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> AgregarPersona(PersonaDTO personas)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
            new SqlParameter("@opc", "CREAR"),
            new SqlParameter("@nombre", personas.Nombre),
            new SqlParameter("@apellido", personas.Apellido),
            new SqlParameter("@identificacion", personas.Identificacion),
            new SqlParameter("@tipo_identificacion", personas.TipoIdentificacion),
            new SqlParameter("@sexo", personas.Sexo),
            new SqlParameter("@id_empresa", personas.IdEmpresa),
            new SqlParameter("@id_dependencias", personas.IdDependencias)
        };

                string sql = $"dbo.Sp_Personas @opc = @opc, @nombre = @nombre, @apellido = @apellido, @identificacion = @identificacion, @tipo_identificacion = @tipo_identificacion, @sexo = @sexo, @id_empresa = @id_empresa, @id_dependencias = @id_dependencias";
                var response = await _ejercicioContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Persona>> ListarPersonas()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"dbo.Sp_Personas @opc = @opc";
                var response = await _ejercicioContext.Personas.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> EliminarPersona(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@id", id)
                };

                string sql = $"dbo.Sp_Personas @opc = @opc, @id = @id";
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
