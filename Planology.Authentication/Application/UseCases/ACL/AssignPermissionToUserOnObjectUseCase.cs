using Domain.Entities;
using Domain.IRepository;

namespace Application.UseCases.ACL
{
    public class AssignPermissionToUserOnObjectUseCase
    {
        private readonly IAccessControlEntryRepository _aceRepository;

        public AssignPermissionToUserOnObjectUseCase(IAccessControlEntryRepository aceRepository)
        {
            _aceRepository = aceRepository;
        }

        public async Task ExecuteAsync(Guid userId, Guid permissionResourceTypeId, PermissionEnum permission)
        {
            var entry = new AccessControlEntry(userId, permissionResourceTypeId, permission);
            await _aceRepository.AddAsync(entry);
        }
    }

}
