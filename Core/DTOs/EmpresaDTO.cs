using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class EmpresaDTO
    {
        public int Id { get; set; }

        public string? NombreEmpresa { get; set; }

        public string? DireccionEmpresa { get; set; }
    }
}
