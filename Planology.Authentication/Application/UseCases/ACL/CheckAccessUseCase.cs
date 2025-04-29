using Application.Requests.ACL;

namespace Application.UseCases.ACL
{
    public class CheckAccessUseCase
    {
        private readonly IAclRepository _aclRepository;

        public CheckAccessUseCase(IAclRepository aclRepository)
        {
            _aclRepository = aclRepository;
        }

        public async Task<bool> ExecuteAsync(CheckAccessRequest request)
        {
            return await _aclRepository.HasPermissionAsync(
                request.UserId, request.ResourceType, request.ResourceId, request.Permission);
        }
    }
}
