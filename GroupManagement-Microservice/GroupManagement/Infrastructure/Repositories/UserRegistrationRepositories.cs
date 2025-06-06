using DittoBox.API.GroupManagement.Domain.Models.ValueObject;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;

namespace DittoBox.API.GroupManagement.Infrastructure.Repositories
{
    public class UserRegistrationRepositories : BaseRepository<UserRegistration>, IUserRegistrationRepository
    {
        public UserRegistrationRepositories(ApplicationDbContext context) : base(context)
        {
        }
    }
}
