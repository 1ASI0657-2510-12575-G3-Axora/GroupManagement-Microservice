using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Domain.Repositories;


namespace DittoBox.API.GroupManagement.Domain.Repositories
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        public Task<IEnumerable<int>> GetProfileCountByGroupId(int groupId);
        public Task<IEnumerable<int>> GetContainerCountByGroupId(int groupId);
    }
}
