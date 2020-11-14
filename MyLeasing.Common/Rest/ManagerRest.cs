namespace MyLeasing.Common.Rest
{
    public class ManagerRest: BaseRest
    {
        public UserRest User { get; set; }

        public string Password { get; set; }
    }
}
