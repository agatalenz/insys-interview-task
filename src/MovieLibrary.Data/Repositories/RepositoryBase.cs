using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected MovieLibraryContext _context { get; set; }

        public RepositoryBase(MovieLibraryContext context)
        {
            _context = context;
        }

        public async virtual Task<int> CreateAsync(TEntity entity)
        {
            var created = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return created.Entity.Id;
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(int id) 
            => await _context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);

        public virtual IQueryable<TEntity> List()
             => _context.Set<TEntity>().OrderBy(entity => entity.Id);

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
