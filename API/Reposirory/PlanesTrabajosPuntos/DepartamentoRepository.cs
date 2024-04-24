using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Reposirory.PlanesTrabajosPuntos
{
    public class PlanTrabajoPuntoRepository : IPlanTrabajoPuntoRepository
    {
        private readonly DbTest3Context db;
        public PlanTrabajoPuntoRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<PlanTrabajoPunto> AddRowAsync(PlanTrabajoPunto document)
        {
            db.PlanesTrabajosPuntos.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<PlanTrabajoPunto>> GetAllAsync()
        {
            var documents = await db.PlanesTrabajosPuntos
                .ToListAsync();
            return documents;
        }

        public async Task<PlanTrabajoPunto?> GetOneAsync(int id)
        {
            var document = await db.PlanesTrabajosPuntos
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<PlanTrabajoPunto> RemoveAsync(PlanTrabajoPunto document)
        {
            db.PlanesTrabajosPuntos.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<PlanTrabajoPunto> UpdateAsync(PlanTrabajoPunto document)
        {
            db.PlanesTrabajosPuntos.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
