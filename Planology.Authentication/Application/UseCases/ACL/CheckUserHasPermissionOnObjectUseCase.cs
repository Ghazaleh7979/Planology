using Application.Requests.ACL;
using Domain.IRepository;

namespace Application.UseCases.ACL
{
    public class CheckUserHasPermissionOnObjectUseCase
    {
        private readonly IAccessControlEntryRepository _aceRepository;

        public CheckUserHasPermissionOnObjectUseCase(IAccessControlEntryRepository aceRepository)
        {
            _aceRepository = aceRepository;
        }

        public async Task<bool> ExecuteAsync(CheckPermissionRequest request)
        {
            var permissions = await _aceRepository.GetPermissionsAsync(request.UserId, request.PermissionResourceTypeId);
            return permissions.Any(p => p.Permission == request.Permission);
        }
    }

}
