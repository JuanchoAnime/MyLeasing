namespace MyLeasing.Common.Rest
{
    public class UserRest
    {
        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string UserName { get; set; }
    }
}
