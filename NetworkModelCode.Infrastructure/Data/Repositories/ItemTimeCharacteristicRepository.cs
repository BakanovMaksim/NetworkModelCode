using Microsoft.EntityFrameworkCore;

using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Domain.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Infrastructure.Data.Repositories
{
    public class ItemTimeCharacteristicRepository : IRepository<ItemTimeCharacteristic>
    {
        private NetworkModelContext Context { get; }

        public ItemTimeCharacteristicRepository(NetworkModelContext context)
        {
            Context = context;
        }

        public IEnumerable<ItemTimeCharacteristic> GetAll()
        {
            return Context
                .ItemsTimeCharacteristic
                .AsNoTracking()
                .ToList() ?? new List<ItemTimeCharacteristic>();
        }

        public async Task<ItemTimeCharacteristic> GetByIdAsync(int id)
        {
            return await Context
                .ItemsTimeCharacteristic
                .FindAsync(id) ?? new ItemTimeCharacteristic();
        }

        public async Task AddAsync(ItemTimeCharacteristic entity)
        {
            if (entity != null)
            {
                await Context.ItemsTimeCharacteristic.AddAsync(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<ItemTimeCharacteristic> entities)
        {
            if(entities.Count() > 0)
            {
                await Context.AddRangeAsync(entities);
                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(ItemTimeCharacteristic entity)
        {
            if (entity != null)
            {
                Context.ItemsTimeCharacteristic.Update(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var itemTimeCharacteristic = Context.ItemsTimeCharacteristic.FirstOrDefault(p => p.Id == id);

            if(itemTimeCharacteristic != null)
            {
                Context.ItemsTimeCharacteristic.Remove(itemTimeCharacteristic);
                await Context.SaveChangesAsync();
            }
        }
    }
}
