namespace MyLeasing.Common.Rest
{
    public class ChangePasswordRest
    {
        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
