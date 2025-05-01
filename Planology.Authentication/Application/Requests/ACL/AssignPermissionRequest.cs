namespace Application.Requests.ACL
{
    public class AssignPermissionRequest
    {
        public Guid UserId { get; set; }
        public Guid PermissionResourceTypeId { get; set; }
        public PermissionEnum Permission { get; set; }
    }
}
