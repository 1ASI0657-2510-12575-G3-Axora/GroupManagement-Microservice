
using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Models.ValueObject;

namespace DittoBox.API.GroupManagement.Domain.Models.Resources
{
    public record GroupResource(
        int Id,
        string Name,
        Location Location,
        int AccountId,
        FacilityType FacilityType,
        int? ContainerCount,
        int? ProfileCount
    )
    {

        public static GroupResource FromGroup(Group group)
        {
            return new GroupResource(group.Id, group.Name, Location.FromLocation(group.Location), group.AccountId, group.FacilityType, group.ContainerCount, group.ProfileCount);
        }
    };


}