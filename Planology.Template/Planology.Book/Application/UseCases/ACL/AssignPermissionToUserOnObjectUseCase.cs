using Application.Requests.ACL;
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

        public async Task ExecuteAsync(AssignPermissionRequest request)
        {
            var entry = new AccessControlEntry(request.UserId, request.PermissionResourceTypeId, request.Permission);
            await _aceRepository.AddAsync(entry);
        }
    }

}
