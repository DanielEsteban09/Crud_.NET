using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DependenciumDTO
    {
        public int? Id { get; set; }

        public string? NombreDependencia { get; set; }

        //public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
    }
}
