using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
  
    public class GenericDataService<T> : IDataService<T> where T :DomainName
    { 
        private readonly SimpleTraderDbContext _context;

        public GenericDataService(SimpleTraderDbContext context)
        {
            _context = context;
        }

        public async  Task<T> Create(T entity)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> createcontext = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return (T)createcontext.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id==id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           IEnumerable<T> entity = await _context.Set<T>().ToListAsync();
            return entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
