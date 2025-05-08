namespace Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpiryDate { get; set; }

        public RefreshToken(string userId, string token, DateTime expiryDate)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Token = token;
            ExpiryDate = expiryDate;
        }
    }
}
