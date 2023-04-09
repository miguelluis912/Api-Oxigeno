using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Oxigeno.DTO.PacienteDTO;
using Api_Oxigeno.DTO;
using Api_Oxigeno.DTO.DatosModelos;
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

            // CreateMap<InscripcionOxigeno, DatosPrescripcion>();

            CreateMap<Paciente, DatosPacienteDTO>()
                .ForMember(dtoP => dtoP.id_paciente, ModelPaciente => ModelPaciente.MapFrom(p => p.Id))
                .ForMember(dtoP => dtoP.nombres, ModelPaciente => ModelPaciente.MapFrom(p => p.Nombre))
                .ForMember(dtoP => dtoP.apellido_materno, ModelPaciente => ModelPaciente.MapFrom(p => p.ApellidoPaterno))
                .ForMember(dtoP => dtoP.apellido_materno, ModelPaciente => ModelPaciente.MapFrom(p => p.ApellidoMaterno))
                .ForMember(dtoP => dtoP.sexo, ModelPaciente => ModelPaciente.MapFrom(p => p.Sexo))
                .ForMember(dtoP => dtoP.curp, ModelPaciente => ModelPaciente.MapFrom(p => p.Curp))
                .ForMember(dtoP => dtoP.rfc, ModelPaciente => ModelPaciente.MapFrom(p => p.Rfc));

            CreateMap<OrdenTrabajo, DatosOrdenTrabajoDTO>()
                .ForMember(dtoT => dtoT.id_orden, ModelOrdenT => ModelOrdenT.MapFrom(d => d.Id))
                .ForMember(dtoT => dtoT.fecha_validacion, ModelOrdenT => ModelOrdenT.MapFrom(d => d.FechasValidacion))
                .ForMember(dtoT => dtoT.mes_corriente, ModelOrdenT => ModelOrdenT.MapFrom(d => d.MesCorriente))
                .ForMember(dtoT => dtoT.fecha_entra_oxigeno, ModelOrdenT => ModelOrdenT.MapFrom(d => d.FechaEntregaOxigeno))
                .ForMember(dtoT => dtoT.status, ModelOrdenT => ModelOrdenT.MapFrom(d => d.Status));

            CreateMap<InscripcionOxigeno, DatosPrescripcionDTO>();

            CreateMap<Direccion, DatosDireccionDTO>()
                .ForMember(dtoDir => dtoDir.id_direccion, ModelDir => ModelDir.MapFrom(dm => dm.Id))
                .ForMember(dtoDir => dtoDir.direccion_completa, ModelDir => ModelDir.MapFrom(dm => dm.Direccion_completa))
                .ForMember(dtoDir => dtoDir.numero_interior, ModelDir => ModelDir.MapFrom(dm => dm.NumInterior))
                .ForMember(dtoDir => dtoDir.numero_exterior, ModelDir => ModelDir.MapFrom(dm => dm.NumExterior))
                .ForMember(dtoDir => dtoDir.codigo_postal, ModelDir => ModelDir.MapFrom(dm => dm.CodigoPostal))
                .ForMember(dtoDir => dtoDir.referencia, ModelDir => ModelDir.MapFrom(dm => dm.Referencia))
                .ForMember(dtoDir => dtoDir.calle, ModelDir => ModelDir.MapFrom(dm => dm.Calle));



        }


    }
}