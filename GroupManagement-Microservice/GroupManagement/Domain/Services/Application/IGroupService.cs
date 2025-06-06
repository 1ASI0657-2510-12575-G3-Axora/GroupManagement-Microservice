using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Models.ValueObject;

namespace DittoBox.API.GroupManagement.Domain.Services.Application
{
    public interface IGroupService
    {
        public Task<Group> CreateGroup(int accountId, string name, Location location, FacilityType facilityType);
        public Task<Group> GetGroup(int id);
        public Task<IEnumerable<Group>> GetGroups(int accountId);
        public Task<Group> UpdateGroup(int id, string name, Location location);
        public Task DeleteGroup(int id);
        public Task RegisterContainer(int groupId, int containerId);

        public Task<IEnumerable<Group>> GetGroupsByAccountId(int accountId);
    }
}