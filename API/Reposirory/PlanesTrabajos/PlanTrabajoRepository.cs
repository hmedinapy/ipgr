using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Reposirory.PlanesTrabajos
{
    public class PlanTrabajoRepository : IPlanTrabajoRepository
    {
        private readonly DbTest3Context db;
        public PlanTrabajoRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<PlanTrabajo> AddRowAsync(PlanTrabajo document)
        {
            db.PlanesTrabajos.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<PlanTrabajo>> GetAllAsync()
        {
            var documents = await db.PlanesTrabajos
                //.Include(x => x.IdDepartamentoNavigation)
                .Include(x => x.IdAreaAuditadaNavigation)
                .ToListAsync();
            return documents;
        }

        public async Task<PlanTrabajo?> GetOneAsync(int id)
        {
            var document = await db.PlanesTrabajos
                //.Include(x => x.IdDepartamentoNavigation)
                .Include(x => x.IdAreaAuditadaNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<PlanTrabajo> RemoveAsync(PlanTrabajo document)
        {
            db.PlanesTrabajos.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<PlanTrabajo> UpdateAsync(PlanTrabajo document)
        {
            db.PlanesTrabajos.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
