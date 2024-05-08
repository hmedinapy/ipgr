using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository.to_remove.Roles
{
    public class RolRepository : IRolRepository
    {
        private readonly DbTest3Context db;
        public RolRepository(DbTest3Context db)
        {
            this.db = db;
        }

        public async Task<Rol> AddRowAsync(Rol document)
        {
            db.Roles.Add(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<List<Rol>> GetAllAsync()
        {
            var documents = await db.Roles
                .ToListAsync();
            return documents;
        }

        public async Task<Rol?> GetOneAsync(int id)
        {
            var document = await db.Roles
                .FirstOrDefaultAsync(x => x.Id == id);
            return document;
        }

        public async Task<Rol> RemoveAsync(Rol document)
        {
            db.Roles.Remove(document);
            await db.SaveChangesAsync();
            return document;
        }

        public async Task<Rol> UpdateAsync(Rol document)
        {
            db.Roles.Update(document);
            await db.SaveChangesAsync();
            return document;
        }
    }
}
