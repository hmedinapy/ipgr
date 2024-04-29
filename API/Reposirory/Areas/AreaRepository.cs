using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Reposirory.Areas
{
    public class AreaRepository : IDbDataSet<Area> // where T : AnalisisRiesgo // IAnalisisRiesgoRepository // : IAreaRepository
    {
        private readonly DbTest3Context db;
        public AreaRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<Area> AddRowAsync(Area document)
        {
            db.Areas.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<Area>> GetAllAsync()
        {
            var documents = await db.Areas
                .Include(x => x.IdDepartamentoNavigation)
                .Include(x => x.IdEmpresaNavigation)
                .ToListAsync();
            return documents;
        }

        public async Task<Area?> GetOneAsync(int id)
        {
            var document = await db.Areas
                .Include(x => x.IdDepartamentoNavigation)
                .Include(x => x.IdEmpresaNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<Area> RemoveAsync(Area document)
        {
            db.Areas.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<Area> UpdateAsync(Area document)
        {
            db.Areas.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
