﻿using AutoMapper;
using Core.Data;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Mappings
{
    public class Automapper: Profile
    {
        public Automapper() {
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<Dependencium, DependenciumDTO>();
            CreateMap<Persona, PersonaDTO>();
        }
    }
}
