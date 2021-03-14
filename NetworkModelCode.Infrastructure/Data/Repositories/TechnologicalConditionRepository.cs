using Microsoft.EntityFrameworkCore;

using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Domain.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Infrastructure.Data.Repositories
{
    public class TechnologicalConditionRepository : IRepository<TechnologicalCondition>
    {
        private NetworkModelContext Context { get; }

        public TechnologicalConditionRepository(NetworkModelContext context)
        {
            Context = context;
        }

        public IEnumerable<TechnologicalCondition> GetAll()
        {
            return Context
                .TechnologicalConditions
                .AsNoTracking()
                .ToList() ?? new List<TechnologicalCondition>();
        }

        public async Task<TechnologicalCondition> GetByIdAsync(int id)
        {
            return await Context
                .TechnologicalConditions
                .FindAsync(id) ?? new TechnologicalCondition();
        }

        public async Task AddAsync(TechnologicalCondition entity)
        {
            if (entity != null)
            {
                await Context.TechnologicalConditions.AddAsync(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<TechnologicalCondition> entities)
        {
            if(entities.Count() > 0)
            {
                await Context.TechnologicalConditions.AddRangeAsync(entities);
                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TechnologicalCondition entity)
        {
            if(entity != null)
            {
                Context.TechnologicalConditions.Update(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var itemDataSource = Context.TechnologicalConditions.FirstOrDefault(p => p.Id == id);

            if(itemDataSource != null)
            {
                Context.TechnologicalConditions.Remove(itemDataSource);
                await Context.SaveChangesAsync();
            }
        }
    }
}
