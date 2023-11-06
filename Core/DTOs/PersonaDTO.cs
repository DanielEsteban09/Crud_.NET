using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PersonaDTO
    {
        public int? Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int? Identificacion { get; set; }

        public string? TipoIdentificacion { get; set; }

        public string? Sexo { get; set; }

        public int? IdEmpresa { get; set; }

        public int? IdDependencias { get; set; }

        //public virtual DependenciumDTO? IdDependenciasNavigation { get; set; }

        //public virtual Empresa? IdEmpresaNavigation { get; set; }
    }
}
