using Microsoft.EntityFrameworkCore;

using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Domain.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkModelCode.Infrastructure.Data.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private NetworkModelContext Context { get; }

        public ProjectRepository(NetworkModelContext context)
        {
            Context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return Context
                .Projects
                .AsNoTracking()
                .ToList()?? new List<Project>();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await Context
                .Projects
                .FindAsync(id) ?? new Project();
        }

        public async Task AddAsync(Project entity)
        {
            if (entity != null)
            {
                await Context.Projects.AddAsync(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task AddRangeAsync(IEnumerable<Project> entities)
        {
            if (entities.Count() > 0)
            {
                await Context.Projects.AddRangeAsync(entities);
                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Project entity)
        {
            if (entity != null)
            {
                Context.Projects.Update(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var project = Context.Projects.FirstOrDefault(p => p.Id == id);

            if (project != null)
            {
                Context.Projects.Remove(project);
                await Context.SaveChangesAsync();
            }
        }
    }
}
