using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly SmartContext _context;
        private DbSet<T> _dataset;
        public Repository(SmartContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public Task<T?> SelectAsync(int id)
        {
            try
            {
                return _dataset.Where(i => i.Id.Equals(id)).SingleOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.OrderBy(i => i.Id).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Add(T item)
        {
            try
            {
                _dataset.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> ExistAsync(int id)
        {
            try
            {
                return await _dataset.AnyAsync(i => i.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<T?> Update(T item)
        {
            try
            {
                var result = await _dataset.Where(i => i.Id.Equals(item.Id)).SingleOrDefaultAsync();
                if (result == null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _dataset.Where(i => i.Id.Equals(id)).SingleOrDefaultAsync();
                if (result == null)
                    return false;
                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
