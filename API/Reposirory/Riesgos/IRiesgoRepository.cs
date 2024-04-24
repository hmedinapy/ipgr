using API.Models;

namespace API.Reposirory.Riesgos
{
    public interface IRiesgoRepository
    {
        public Task<List<Riesgo>> GetAllAsync();
        public Task<Riesgo?> GetOneAsync(int id);
        public Task<Riesgo> AddRowAsync(Riesgo document);
        public Task<Riesgo> UpdateAsync(Riesgo document);
        public Task<Riesgo> RemoveAsync(Riesgo document);
    }
}
