namespace Application.ServiceInterfaces
{
    public interface IAccessControlService
    {
        bool HasAccess(string role, string permission);
    }
}
