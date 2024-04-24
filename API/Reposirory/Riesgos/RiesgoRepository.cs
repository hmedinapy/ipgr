using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Reposirory.Riesgos
{
    public class RiesgoRepository : IRiesgoRepository
    {
        private readonly DbTest3Context db;
        public RiesgoRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<Riesgo> AddRowAsync(Riesgo document)
        {
            db.Riesgos.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<Riesgo>> GetAllAsync()
        {
            var documents = await db.Riesgos
                .ToListAsync();
            return documents;
        }

        public async Task<Riesgo?> GetOneAsync(int id)
        {
            var document = await db.Riesgos
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<Riesgo> RemoveAsync(Riesgo document)
        {
            db.Riesgos.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<Riesgo> UpdateAsync(Riesgo document)
        {
            db.Riesgos.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
