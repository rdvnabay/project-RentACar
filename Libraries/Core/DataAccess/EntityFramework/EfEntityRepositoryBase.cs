using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>, IEntityAsyncRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        protected TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity) => _context.Add(entity);

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public void AddRange(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Add(entity);
            }
        }

        public async Task AddRangeAsync(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
        }
        public void Update(TEntity entity) => _context.Update(entity);

        public void UpdateRange(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity) => _context.Remove(entity);

        public void DeleteRange(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Remove(entity);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                ? await _context.Set<TEntity>().ToListAsync()
                : await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) => _context.Set<TEntity>().FirstOrDefault(filter);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression) => await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id);
        public async Task<TEntity> GetByIdAsync(int? id) => await _context.Set<TEntity>().FindAsync(id);

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
