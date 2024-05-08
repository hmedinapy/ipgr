using API.Models;

namespace API.Core.Repository.to_remove.PlanesTrabajosPuntos
{
    public interface IPlanTrabajoPuntoRepository
    {
        public Task<List<PlanTrabajoPunto>> GetAllAsync();
        public Task<PlanTrabajoPunto?> GetOneAsync(int id);
        public Task<PlanTrabajoPunto> AddRowAsync(PlanTrabajoPunto document);
        public Task<PlanTrabajoPunto> UpdateAsync(PlanTrabajoPunto document);
        public Task<PlanTrabajoPunto> RemoveAsync(PlanTrabajoPunto document);
    }
}
