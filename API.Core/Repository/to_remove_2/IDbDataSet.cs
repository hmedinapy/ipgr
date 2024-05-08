namespace API.Core.Repository.to_remove_2;

public interface IDbDataSet<T> where T : class
{
    public Task<List<T>> GetAllAsync();
    public Task<T?> GetOneAsync(int id);
    public Task<T> AddRowAsync(T document);
    public Task<T> UpdateAsync(T document);
    public Task RemoveAsync(int id);
}
