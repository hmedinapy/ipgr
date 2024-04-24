using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Reposirory.Empresas
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DbTest3Context db;
        public EmpresaRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<Empresa> AddRowAsync(Empresa document)
        {
            db.Empresas.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<Empresa>> GetAllAsync()
        {
            var documents = await db.Empresas
                .ToListAsync();
            return documents;
        }

        public async Task<Empresa?> GetOneAsync(int id)
        {
            var document = await db.Empresas
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<Empresa> RemoveAsync(Empresa document)
        {
            db.Empresas.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<Empresa> UpdateAsync(Empresa document)
        {
            db.Empresas.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
