namespace Domain.Entities
{
    public class UserPermission
    {
        public Guid Id { get; private set; }
        public Guid ObjectId { get; private set; }
        public string ObjectType { get; private set; }
        public string Action { get; private set; }

        private UserPermission() { }

        public UserPermission(Guid objectId, string objectType, string action)
        {
            Id = Guid.NewGuid();
            ObjectId = objectId;
            ObjectType = objectType;
            Action = action;
        }
    }
}
