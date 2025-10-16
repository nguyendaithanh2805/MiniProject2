using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abstractions.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MenuRepository : IRepository<Menu>
    {
        private readonly AppDbContext _dbContext;

        public MenuRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Menu entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Menu.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Menu entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Menu.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Menu>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Menu.Include(m => m.News).ToListAsync(cancellationToken);
        }

        public async Task<Menu> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Menu.Include(m => m.News).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Menu entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
