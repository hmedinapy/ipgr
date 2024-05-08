using API.Data.Entities;

namespace API.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private IGenericRepository<Area> _areas;
        private IGenericRepository<Departamento> _departamentos;
        private IGenericRepository<AnalisisRiesgo> _analisisRiesgos;
        private IGenericRepository<Empresa> _empresas;
        private IGenericRepository<PlanTrabajo> _planesTrabajos;
        private IGenericRepository<PlanTrabajoPunto> _planesTrabajosPuntos;
        private IGenericRepository<Riesgo> _riesgos;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Area> Areas => _areas ??= new GenericRepository<Area>(_context);
        public IGenericRepository<Departamento> Departamentos => _departamentos ??= new GenericRepository<Departamento>(_context);
        public IGenericRepository<AnalisisRiesgo> AnalisisRiesgos => _analisisRiesgos ??= new GenericRepository<AnalisisRiesgo>(_context);
        public IGenericRepository<Empresa> Empresas => _empresas ??= new GenericRepository<Empresa>(_context);
        public IGenericRepository<PlanTrabajo> PlanesTrabajos => _planesTrabajos ??= new GenericRepository<PlanTrabajo>(_context);
        public IGenericRepository<PlanTrabajoPunto> PlanesTrabajosPuntos => _planesTrabajosPuntos ??= new GenericRepository<PlanTrabajoPunto>(_context);
        public IGenericRepository<Riesgo> Riesgos => _riesgos ??= new GenericRepository<Riesgo>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
