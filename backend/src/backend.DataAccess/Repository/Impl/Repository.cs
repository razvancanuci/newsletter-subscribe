using backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.DataAccess.Repository.Impl
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly SubscriberContext _context;
        public Repository(SubscriberContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (typeof(T) == typeof(Subscriber))
            {
                await _context.Subscribers.AddAsync((Subscriber)(object)entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return default;
        }

        public async Task<T> DeleteByAStringAsync(string email)
        {
            if (typeof(T) == typeof(Subscriber))
            {
                var subscriber = (await _context.Subscribers.ToListAsync()).SingleOrDefault(x => x.Email == email);
                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
                return (T)(object)subscriber;
            }
            return default;
        }

        public async Task<T> DeleteByGuidAsync(Guid id)
        {
            if (typeof(T) == typeof(Subscriber))
            {
                var subscriber = (await _context.Subscribers.ToListAsync()).SingleOrDefault(x => x.Id == id);
                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
                return (T)(object)subscriber;
            }
            return default;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Subscriber))
            {
                return (IEnumerable<T>)await _context.Subscribers.ToListAsync();
            }
            return default;
        }

        public async Task<T?> GetByGuidAsync(Guid id)
        {
            if (typeof(T) == typeof(Subscriber))
            {
                return (T)(object)(await _context.Subscribers.ToListAsync()).SingleOrDefault(x => x.Id == id);
            }
            return default;
        }

        public async Task<T?> GetByStringAsync(string email)
        {
            if (typeof(T) == typeof(Subscriber))
            {
                return (T)(object)(await _context.Subscribers.ToListAsync()).SingleOrDefault(x => x.Email == email);
            }
            return default;
        }


    }

}
