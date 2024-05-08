using API.Data.Entities;

namespace API.Core.Repository.to_remove.Empresas
{
    public interface IEmpresaRepository
    {
        public Task<List<Empresa>> GetAllAsync();
        public Task<Empresa?> GetOneAsync(int id);
        public Task<Empresa> AddRowAsync(Empresa document);
        public Task<Empresa> UpdateAsync(Empresa document);
        public Task<Empresa> RemoveAsync(Empresa document);
    }
}
