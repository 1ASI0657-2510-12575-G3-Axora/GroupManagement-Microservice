using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Models.Queries;
using DittoBox.API.GroupManagement.Domain.Models.ValueObject;

namespace DittoBox.API.GroupManagement.Domain.Services.Domain
{
    public interface IGroupManagementService
    {
        public Task CreateGroup(int accountId, string name, Location location, FacilityType facilityType);

        // public Task UpdateGroup(UpdateGroupCommand command);
        // public Task DeleteGroup(DeleteGroupCommand command);
    //     public Task AssignUserToGroup(AssignUserToGroupCommand command);
    //     public Task RemoveUserFromGroup(RemoveUserFromGroupCommand command);
    //     public Task UpdateGroupDetails(UpdateGroupDetailsCommand command);
    // }
    }
}
