using DittoBox.API.GroupManagement.Domain.Models.Resources;

namespace DittoBox.API.GroupManagement.Domain.Models.Commands
{
    public interface ICreateGroupCommandHandler
    {
        public Task<GroupResource> Handle(CreateGroupCommand command);
    }
}