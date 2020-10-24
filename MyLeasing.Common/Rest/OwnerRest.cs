namespace MyLeasing.Common.Rest
{
    public class OwnerRest
    {
        public int Id { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FixedPhone { get; set; }

        public string CellPhone { get; set; }

        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
