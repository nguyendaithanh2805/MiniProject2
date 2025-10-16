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
    public class NewsRepository : IRepository<News>
    {
        private readonly AppDbContext _dbContext;

        public NewsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(News entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.News.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(News entity, CancellationToken cancellationToken = default)
        {
            _dbContext.News.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<News>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.News.ToListAsync(cancellationToken);
        }

        public async Task<News> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.News.FindAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(News entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
