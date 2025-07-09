using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.GroupManagement.Infrastructure.Repositories
{
    public class GroupRepository(ApplicationDbContext context) 
        : BaseRepository<Group>(context), IGroupRepository
    {
        public async Task<IEnumerable<int>> GetProfileCountByGroupId(int groupId)
        {
            return await context.Groups
                .Where(g => g.Id == groupId)
                .Select(g => g.ProfileCount)
                .ToListAsync();
        }

        public async Task<IEnumerable<int>> GetContainerCountByGroupId(int groupId)
        {
            return await context.Groups
                .Where(g => g.Id == groupId)
                .Select(g => g.ContainerCount)
                .ToListAsync();
        }

        public async Task<IEnumerable<Group>> ListByAccountId(int accountId)
        {
            return await context.Groups
                .Where(g => g.AccountId == accountId)
                .ToListAsync();
        }
        
        public async Task<Group?> GetByIdWithLocation(int id)
        {
            return await context.Groups
                .Include(g => g.Location)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}