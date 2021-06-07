using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.IRepositories;
using Jarvis.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Jarvis.Infra.Data.Repositories
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : class
    {
        private JarvisDbContext _context;

        public GenericRepositories(JarvisDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();

            return t;
        }

        public async Task Update(T t)
        {
            _context.Set<T>().Update(t);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(T t)
        {
            _context.Set<T>().Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> function)
        {
            return await _context.Set<T>().AnyAsync(function);
        }
    }
}
