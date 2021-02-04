using Microsoft.EntityFrameworkCore;

using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Domain.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Infrastructure.Data.Repositories
{
    public class ItemDataSourceRepository : IRepository<ItemDataSource>
    {
        private NetworkModelContext Context { get; }

        public ItemDataSourceRepository(NetworkModelContext context)
        {
            Context = context;
        }

        public IEnumerable<ItemDataSource> GetAll()
        {
            return Context
                .ItemsDataSource
                .AsNoTracking()
                .ToList() ?? new List<ItemDataSource>();
        }

        public async Task<ItemDataSource> GetByIdAsync(int id)
        {
            return await Context
                .ItemsDataSource
                .FindAsync(id) ?? new ItemDataSource();
        }

        public async Task AddAsync(ItemDataSource entity)
        {
            if (entity != null)
            {
                await Context.ItemsDataSource.AddAsync(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<ItemDataSource> entities)
        {
            if(entities.Count() > 0)
            {
                await Context.ItemsDataSource.AddRangeAsync(entities);
                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(ItemDataSource entity)
        {
            if(entity != null)
            {
                Context.ItemsDataSource.Update(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var itemDataSource = Context.ItemsDataSource.FirstOrDefault(p => p.Id == id);

            if(itemDataSource != null)
            {
                Context.ItemsDataSource.Remove(itemDataSource);
                await Context.SaveChangesAsync();
            }
        }
    }
}
