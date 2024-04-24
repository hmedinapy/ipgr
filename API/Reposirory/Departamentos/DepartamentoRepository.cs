using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Reposirory.Departamentos
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly DbTest3Context db;
        public DepartamentoRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<Departamento> AddRowAsync(Departamento document)
        {
            db.Departamentos.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<Departamento>> GetAllAsync()
        {
            var documents = await db.Departamentos
                .Include(x => x.IdEmpresaNavigation)
                .ToListAsync();
            return documents;
        }

        public async Task<Departamento?> GetOneAsync(int id)
        {
            var document = await db.Departamentos
                .Include(x => x.IdEmpresaNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<Departamento> RemoveAsync(Departamento document)
        {
            db.Departamentos.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<Departamento> UpdateAsync(Departamento document)
        {
            db.Departamentos.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
