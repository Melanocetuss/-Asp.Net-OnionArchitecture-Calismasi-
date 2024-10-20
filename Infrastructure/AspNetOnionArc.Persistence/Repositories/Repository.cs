using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AspNetOnionArcContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AspNetOnionArcContext context)
        {
            _context = context;
            _dbSet =  _context.Set<T>();
        }

        public async Task CreateAsycn(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsycn()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsycn(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveAsycn(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsycn(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}