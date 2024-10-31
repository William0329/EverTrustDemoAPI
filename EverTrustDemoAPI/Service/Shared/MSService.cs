using AutoMapper;

using TverTrustDemoModel.Models;
using TverTrustDemoModel.Models.Shared;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;


namespace EverTrustDemoAPI.Service.Shared
{
    /// <summary>
    /// Ms SQL Service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MSService<T> : IService<T> where T : DbBaseModel
    {
        protected readonly EverTrustDbContext _db;
        private readonly IMapper _mapper;
        private DbSet<T> _dbSet;
        public MSService(EverTrustDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            var dbSetProperty = _db.GetType().GetProperties()
                                   .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                                        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                                        p.PropertyType.GetGenericArguments()[0] == typeof(T));
            if (dbSetProperty != null)
            {
                _dbSet = (DbSet<T>)dbSetProperty.GetValue(_db);
            }
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await GetListAsync(x => true);
        }
        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }
        public async Task<string> CreateAsync(T data)
        {
            await _dbSet.AddAsync(data);
            await _db.SaveChangesAsync();
            return data.Id ?? "";
        }
        public async Task<bool> UpdateAsync(T updatedData)
        {
            var target = _dbSet.FirstOrDefault(x => x.Id == updatedData.Id);
            if (target != null)
            {
                _mapper.Map(updatedData, target);
            }
            var result = _db.SaveChanges();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(IEnumerable<T> updatedDatas)
        {
            foreach (var item in updatedDatas)
            {
                var target = _dbSet.FirstOrDefault(x => x.Id == item.Id);
                if (target != null)
                {
                    _mapper.Map(item, target);
                }
            }
            var result = _db.SaveChanges();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var target = _dbSet.FirstOrDefault(x => x.Id == id);
            if (target != null)
            {
                target.IsDelete = true;
            }
            var result = _db.SaveChanges();
            return result > 0;
        }
        public async Task<bool> DeleteAsync(IEnumerable<string> ids) 
        {
            foreach (var id in ids)
            {
                var target = _dbSet.FirstOrDefault(x => x.Id == id);
                if (target != null)
                {
                    target.IsDelete = true;
                }
            }
            var result = _db.SaveChanges();
            return result > 0;
        }
    }
}
