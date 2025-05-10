namespace Application.Requests.ACL
{
    public class AssignPermissionRequest
    {
        public string UserId { get; set; }
        public Guid PermissionResourceTypeId { get; set; }
        public PermissionEnum Permission { get; set; }
    }
}
