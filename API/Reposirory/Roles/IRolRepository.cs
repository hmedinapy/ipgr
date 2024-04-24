using API.Models;

namespace API.Reposirory.Roles
{
    public interface IRolRepository
    {
        public Task<List<Rol>> GetAllAsync();
        public Task<Rol?> GetOneAsync(int id);
        public Task<Rol> AddRowAsync(Rol document);
        public Task<Rol> UpdateAsync(Rol document);
        public Task<Rol> RemoveAsync(Rol document);
    }
}
