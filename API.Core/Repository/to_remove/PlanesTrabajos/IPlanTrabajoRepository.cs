using API.Models;

namespace API.Core.Repository.to_remove.PlanesTrabajos
{
    public interface IPlanTrabajoRepository
    {
        public Task<List<PlanTrabajo>> GetAllAsync();
        public Task<PlanTrabajo?> GetOneAsync(int id);
        public Task<PlanTrabajo> AddRowAsync(PlanTrabajo document);
        public Task<PlanTrabajo> UpdateAsync(PlanTrabajo document);
        public Task<PlanTrabajo> RemoveAsync(PlanTrabajo document);
    }
}
