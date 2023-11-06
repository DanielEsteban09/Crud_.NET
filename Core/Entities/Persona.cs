using System;
using System.Collections.Generic;

namespace Core.Data;

public partial class Persona
{
    public int? Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Identificacion { get; set; }

    public string? TipoIdentificacion { get; set; }

    public string? Sexo { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdDependencias { get; set; }

    //public virtual Dependencium? IdDependenciasNavigation { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
