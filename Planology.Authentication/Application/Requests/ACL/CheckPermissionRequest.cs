namespace Application.Requests.ACL
{
    public class CheckPermissionRequest
    {
        public Guid UserId { get; set; }
        public Guid PermissionResourceTypeId { get; set; }
        public PermissionEnum Permission { get; set; }
    }
}
