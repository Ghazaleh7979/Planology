namespace Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        private RefreshToken() { }

        public RefreshToken(Guid userId, string token, DateTime expiryDate)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Token = token;
            ExpiryDate = expiryDate;
        }
    }
}
