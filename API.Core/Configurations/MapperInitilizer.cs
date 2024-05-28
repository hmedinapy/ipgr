using API.Core.DTOs;
using API.Core.Models;
using API.Data.Entities;
using AutoMapper;

namespace API.Core.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            //CreateMap<IdentityUser, UserDTO>().ReverseMap();
            CreateMap<AnalisisRiesgo, AnalisisRiesgoDTO>().ReverseMap();
            CreateMap<AnalisisRiesgo, AnalisisRiesgoUpsert>().ReverseMap();
            CreateMap<Area, AreaDTO>().ReverseMap();
            CreateMap<Area, AreaUpsert>().ReverseMap();
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            CreateMap<Departamento, DepartamentoUpsert>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaUpsert>().ReverseMap();
            CreateMap<PlanTrabajo, PlanTrabajoDTO>().ReverseMap();
            CreateMap<PlanTrabajo, PlanTrabajoUpsert>().ReverseMap();
            CreateMap<PlanTrabajoPunto, PlanTrabajoPuntoDTO>().ReverseMap();
            CreateMap<PlanTrabajoPunto, PlanTrabajoPuntoUpsert>().ReverseMap();
            CreateMap<Riesgo, RiesgoDTO>().ReverseMap();
            CreateMap<Riesgo, RiesgoUpsert>().ReverseMap();
        }
    }
}
