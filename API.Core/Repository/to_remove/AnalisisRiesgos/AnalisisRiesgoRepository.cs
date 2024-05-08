using API.Core.Reposirory;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository.to_remove.AnalisisRiesgos
{
    public class AnalisisRiesgoRepository : IDbDataSet<AnalisisRiesgo> // where T : AnalisisRiesgo // IAnalisisRiesgoRepository
    {
        private readonly DbTest3Context db;
        public AnalisisRiesgoRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<AnalisisRiesgo> AddRowAsync(AnalisisRiesgo document)
        {
            db.AnalisisRiesgos.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<AnalisisRiesgo>> GetAllAsync()
        {
            var documents = await db.AnalisisRiesgos
                .ToListAsync();
            return documents;
        }

        public async Task<AnalisisRiesgo?> GetOneAsync(int id)
        {
            var document = await db.AnalisisRiesgos
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<AnalisisRiesgo> RemoveAsync(AnalisisRiesgo document)
        {
            db.AnalisisRiesgos.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AnalisisRiesgo> UpdateAsync(AnalisisRiesgo document)
        {
            db.AnalisisRiesgos.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
