namespace Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; private set; }
        public string Action { get; private set; }
        public string ObjectType { get; private set; }

        public Permission(string action, string objectType)
        {
            Id = Guid.NewGuid();
            Action = action;
            ObjectType = objectType;
        }
    }
}
