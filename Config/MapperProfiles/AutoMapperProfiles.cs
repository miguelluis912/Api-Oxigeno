using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Oxigeno.DTO.PacienteDTO;
using Api_Oxigeno.DTO;
using Api_Oxigeno.DTO.PrescripcionDTO;
using Api_Oxigeno.Models;

namespace Api_Oxigeno.Config.MapperProfiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Paciente, getPacienteDTO>()
            .ForMember(o => o.nombres, dtopaciente => dtopaciente.MapFrom(e => e.Nombre))
            .ForMember(o => o.apellido_paterno, dtopaciente => dtopaciente.MapFrom(e => e.ApellidoPaterno))
            .ForMember(o => o.apellido_materno, dtopaciente => dtopaciente.MapFrom(e => e.ApellidoMaterno))
            .ForMember(o => o.curp, dtopaciente => dtopaciente.MapFrom(e => e.Curp))
            .ForMember(o => o.rfc, dtopaciente => dtopaciente.MapFrom(e => e.Rfc))
            .ForMember(o => o.correo, dtopaciente => dtopaciente.MapFrom(e => e.Correo))
            .ForMember(o => o.telefono, dtopaciente => dtopaciente.MapFrom(e => e.Telefono));

            CreateMap<InscripcionOxigeno, DatosPrescripcion>();
            // .ForMember(w => w.id, dtopaciente => dtopaciente.MapFrom(r => r.InscripcionOxigeno.Id))
            // .ForMember(w => w.id_suario, dtopaciente => dtopaciente.MapFrom(r => r.InscripcionOxigeno.IdUser))
            // .ForMember(w => w.id_prescripcion_paciente, dtopaciente => dtopaciente.MapFrom(r => r.InscripcionOxigeno.IdPrescripcionPaciente))
            // .ForMember(w => w.id_paciente, dtopaciente => dtopaciente.MapFrom(r => r.InscripcionOxigeno.IdPaciente));
        }


    }
}