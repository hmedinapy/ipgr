using API.Models;

namespace API.Reposirory.Areas
{
    public interface IAreaRepository
    {
        public Task<List<Area>> GetAllAsync();
        public Task<Area?> GetOneAsync(int id);
        public Task<Area> AddRowAsync(Area document);
        public Task<Area> UpdateAsync(Area document);
        public Task<Area> RemoveAsync(Area document);
    }
}
