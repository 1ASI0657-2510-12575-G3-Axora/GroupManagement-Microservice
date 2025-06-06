using DittoBox.API.GroupManagement.Domain.Models.Queries;
using DittoBox.API.GroupManagement.Domain.Models.Resources;
using DittoBox.API.GroupManagement.Domain.Repositories;

namespace DittoBox.API.GroupManagement.Domain.Models.Handlers.Internal
{
    public interface IGetGroupQueryHandler
    {
        public Task<GroupResource?> Handle(GetGroupQuery query);
    }
}