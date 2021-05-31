using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public async Task AddAsync(TEntity entity)
        {
            var context = new TContext();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public void AddMultiple(IList<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    context.Add(entity);
                    context.SaveChanges();
                }
            }
        }
        public async Task AddAsync(IList<TEntity> entities)
        {
            var context = new TContext();
            foreach (var entity in entities)
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }
        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
             await _context.SaveChangesAsync();
        }
        public void Delete(IList<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    context.Remove(entity);
                    context.SaveChanges();
                }
            }
        }
        public async Task DeleteAsync(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public int Delete(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var context = new TContext();
            return context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            var context = new TContext();
            return expression == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(expression).ToListAsync();
        }
        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
        public async Task<TEntity> GetByIdAsync(int? id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(IList<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public async Task UpdateAsync(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }
        public int SaveChanges()
        {
            using (var context = new TContext())
            {
                return context.SaveChanges();
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            using (var context = new TContext())
            {
                return await context.SaveChangesAsync();
            }
        }
    }
}
