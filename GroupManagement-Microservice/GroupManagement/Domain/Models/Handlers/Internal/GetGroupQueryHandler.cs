using DittoBox.API.GroupManagement.Domain.Models.Queries;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.GroupManagement.Domain.Services.Application;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal
{
    public class GetGroupQueryHandler (
        IGroupService groupService
        ) : IGetGroupQueryHandler
        
        {
        public async Task<GroupResource?> Handle(GetGroupQuery query){

            var group = await groupService.GetGroup(query.GroupId);
            if(group == null){
                return null;
            }
            return GroupResource.FromGroup(group);
        }
    }

}