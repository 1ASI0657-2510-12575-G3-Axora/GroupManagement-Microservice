using DittoBox.API.GroupManagement.Domain.Models.Entities;
using DittoBox.API.GroupManagement.Domain.Models.ValueObject;
using DittoBox.API.GroupManagement.Domain.Repositories;
using DittoBox.API.GroupManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.GroupManagement.Domain.Services.Application.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Group> CreateGroup(int accountId, string name, Location location, FacilityType facilityType)
        {
            var group = new Group
            {
                AccountId = accountId,
                Name = name,
                Location = location,
                FacilityType = facilityType
            };

            await _groupRepository.Add(group);
            await _unitOfWork.CompleteAsync();

            return group;
        }

        public async Task DeleteGroup(int id)
        {
            var group = await _groupRepository.GetById(id);
            if (group == null)
                throw new Exception("Group not found");

            await _groupRepository.Delete(group);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Group> GetGroup(int id)
        {
            var group = await _groupRepository.GetByIdWithLocation(id);
            if (group == null)
                throw new Exception("Group not found");

            return group;
        }

        public async Task<IEnumerable<Group>> GetGroups(int accountId)
        {
            var allGroups = await _groupRepository.GetAll();
            return allGroups.Where(g => g.AccountId == accountId);
        }

        public async Task<IEnumerable<Group>> GetGroupsByAccountId(int accountId)
        {
            return await _groupRepository.ListByAccountId(accountId);
        }

        public async Task<Group> UpdateGroup(int id, string name, Location location)
        {
            var group = await _groupRepository.GetById(id);
            if (group == null)
                throw new Exception("Group not found");

            group.Name = name;
            group.Location = location;

            await _groupRepository.Update(group);
            await _unitOfWork.CompleteAsync();

            return group;
        }

        public async Task RegisterContainer(int groupId, int containerId)
        {
            var group = await _groupRepository.GetById(groupId);
            if (group == null)
                throw new Exception("Group not found");

            group.ContainerCount++; // o agregarlo en alguna lista, según tu modelo
            await _groupRepository.Update(group);
            await _unitOfWork.CompleteAsync();
        }
    }
}