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

        public async Task<bool> ExecuteAsync(Guid userId, Guid resourceId, PermissionEnum permission)
        {
            var permissions = await _aceRepository.GetPermissionsAsync(userId, resourceId);
            return permissions.Any(p => p.Permission == permission);
        }
    }

}
