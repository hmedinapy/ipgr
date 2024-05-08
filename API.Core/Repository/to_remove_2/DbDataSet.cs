using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository.to_remove_2;

public class DbDataSet<T> : IDbDataSet<T> where T : class
{
    private readonly DbSet<T> _db;

    public IDbDataSet<T> NativeMongoCollection => (IDbDataSet<T>)_db;

    public DbDataSet(IDbDataSet<T> dbset)
    {
        _db = (DbSet<T>?)dbset;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _db.ToListAsync();
    }

    public async Task<T?> GetOneAsync(int id)
    {
        return await _db.FindAsync(id);
    }
    public async Task<T> AddRowAsync(T document)
    {
        return null;
    }

    public async Task<T> UpdateAsync(T document)
    {
        return null;
    }

    public async Task RemoveAsync(int id)
    {
        var entity = await _db.FindAsync(id);
        if (entity != null)
            _db.Remove(entity);
    }

}
