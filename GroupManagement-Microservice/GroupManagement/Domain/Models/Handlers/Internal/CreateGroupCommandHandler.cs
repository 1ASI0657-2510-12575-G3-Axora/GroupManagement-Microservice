using DittoBox.API.GroupManagement.Domain.Models.Commands;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using DittoBox.API.GroupManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.GroupManagement.Domain.Models.Entities;


namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal
{
    public class CreateGroupCommandHandler(
        IGroupService groupService,
        IUnitOfWork unitOfWork
    ) : ICreateGroupCommandHandler
    {

        public async Task<GroupResource> Handle(CreateGroupCommand command)
        {
            var group = await groupService.CreateGroup(command.AccountId, command.Name, command.Location, command.FacilityType);
            await unitOfWork.CompleteAsync();
            return GroupResource.FromGroup(group);
        }
    }
}