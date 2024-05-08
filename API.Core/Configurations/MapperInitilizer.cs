using API.Core.DTOs;
using API.Data.Entities;
using AutoMapper;

namespace API.Core.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<AnalisisRiesgo, AnalisisRiesgoDTO>().ReverseMap();
            CreateMap<Area, AreaDTO>().ReverseMap();
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<PlanTrabajo, PlanTrabajoDTO>().ReverseMap();
            CreateMap<PlanTrabajoPunto, PlanTrabajoPuntoDTO>().ReverseMap();
            CreateMap<Riesgo, RiesgoDTO>().ReverseMap();
        }
    }
}
