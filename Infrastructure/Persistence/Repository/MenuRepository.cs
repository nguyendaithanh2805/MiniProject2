using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class MenuRepository : IRepository<Menu>
    {
        private readonly AppDbContext _dbContext;

        public MenuRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Menu entity)
        {
            await _dbContext.Menu.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Menu.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Menu.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _dbContext.Menu.ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _dbContext.Menu.FindAsync();
        }

        public async Task UpdateAsync(Menu entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
