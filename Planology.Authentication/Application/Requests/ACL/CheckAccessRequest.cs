namespace Application.Requests.ACL
{
    public class CheckAccessRequest
    {
        public string UserId { get; set; }
        public string ResourceType { get; set; }
        public string ResourceId { get; set; }
        public string Permission { get; set; }
    }
}
