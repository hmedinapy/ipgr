using API.Models;

namespace API.Reposirory.AnalisisRiesgos;

public interface IAnalisisRiesgoRepository
{
    public Task<List<AnalisisRiesgo>> GetAllAsync();
    public Task<AnalisisRiesgo?> GetOneAsync(int id);
    public Task<AnalisisRiesgo> AddRowAsync(AnalisisRiesgo document);
    public Task<AnalisisRiesgo> UpdateAsync(AnalisisRiesgo document);
    public Task<AnalisisRiesgo> RemoveAsync(AnalisisRiesgo document);
}
