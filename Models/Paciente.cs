﻿using System;
using System.Collections.Generic;

namespace Api_Oxigeno.Models
{
    public partial class Paciente
    {
        public ulong Id { get; set; }
        public int? TipoPaciente { get; set; }
        public int IdUser { get; set; }
        public int IdUnidad { get; set; }
        public int IdEntidad { get; set; }
        public int IdTipoDerechohabiencia { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public string Sexo { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string Curp { get; set; } = null!;
        public string Rfc { get; set; } = null!;
        public string? Expediente { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public TimeOnly HoraRegistro { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
