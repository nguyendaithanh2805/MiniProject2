using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
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

        public async Task AddAsync(News entity)
        {
            await _dbContext.News.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(News entity)
        {
            _dbContext.News.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {
            return await _dbContext.News.ToListAsync();
        }

        public async Task<News> GetByIdAsync(int id)
        {
            return await _dbContext.News.FindAsync(id);
        }

        public async Task UpdateAsync(News entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
