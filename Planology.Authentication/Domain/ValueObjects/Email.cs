namespace Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        private Email() { }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\S+@\S+\.\S+$"))
                throw new ArgumentException("Invalid email format.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}
