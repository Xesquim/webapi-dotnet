using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> Add(T item);
        Task<T?> Update(T item);
        Task<bool> ExistAsync(int id);
        Task<T?> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> Delete(int id);
    }
}
