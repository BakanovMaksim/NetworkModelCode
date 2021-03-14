using Microsoft.EntityFrameworkCore;

using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Domain.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Infrastructure.Data.Repositories
{
    public class TimeCharacteristicsRepository : IRepository<TimeCharacteristic>
    {
        private NetworkModelContext Context { get; }

        public TimeCharacteristicsRepository(NetworkModelContext context)
        {
            Context = context;
        }

        public IEnumerable<TimeCharacteristic> GetAll()
        {
            return Context
                .TimeCharacteristics
                .AsNoTracking()
                .ToList() ?? new List<TimeCharacteristic>();
        }

        public async Task<TimeCharacteristic> GetByIdAsync(int id)
        {
            return await Context
                .TimeCharacteristics
                .FindAsync(id) ?? new TimeCharacteristic();
        }

        public async Task AddAsync(TimeCharacteristic entity)
        {
            if (entity != null)
            {
                await Context.TimeCharacteristics.AddAsync(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<TimeCharacteristic> entities)
        {
            if(entities.Count() > 0)
            {
                await Context.AddRangeAsync(entities);
                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TimeCharacteristic entity)
        {
            if (entity != null)
            {
                Context.TimeCharacteristics.Update(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var itemTimeCharacteristic = Context.TimeCharacteristics.FirstOrDefault(p => p.Id == id);

            if(itemTimeCharacteristic != null)
            {
                Context.TimeCharacteristics.Remove(itemTimeCharacteristic);
                await Context.SaveChangesAsync();
            }
        }
    }
}
