using API.Data.Entities;

namespace API.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Area> Areas { get; }
        IGenericRepository<Departamento> Departamentos { get; }
        IGenericRepository<AnalisisRiesgo> AnalisisRiesgos { get; }
        IGenericRepository<Empresa> Empresas { get; }
        IGenericRepository<PlanTrabajo> PlanesTrabajos { get; }
        IGenericRepository<PlanTrabajoPunto> PlanesTrabajosPuntos { get; }
        IGenericRepository<Riesgo> Riesgos { get; }
        Task Save();
    }
}
