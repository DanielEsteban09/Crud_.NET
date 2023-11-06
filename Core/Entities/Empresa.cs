using System;
using System.Collections.Generic;

namespace Core.Data;

public partial class Empresa
{
    public int Id { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? DireccionEmpresa { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
