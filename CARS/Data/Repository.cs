using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CARS.Data
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> 
        where TEntity : class
        where TDbContext : AppDbContext
    {
        private readonly TDbContext _context;

        public Repository(TDbContext c)
        {
            _context = c;
        }

        public async void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            if(entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
