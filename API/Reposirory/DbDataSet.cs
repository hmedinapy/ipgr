using Microsoft.EntityFrameworkCore;

namespace API.Reposirory;

public class DbDataSet<T> : IDbDataSet<T> where T : class
{
    private readonly DbSet<T> dbset;

    public IDbDataSet<T> NativeMongoCollection => (IDbDataSet<T>)this.dbset;

    public DbDataSet(IDbDataSet<T> dbset)
    {
        this.dbset = (DbSet<T>?)dbset;
    }

    public async Task<List<T>> GetAllAsync()
    {
        var documents = await dbset.ToListAsync();
        return documents;

    }

    public Task<T?> GetOneAsync(int id)
    {
        return null;
    }
    public Task<T> AddRowAsync(T document)
    {
        return null;
    }

    public Task<T> UpdateAsync(T document)
    {
        return null;
    }

    public Task<T> RemoveAsync(T document)
    {
        return null;
    }

}
