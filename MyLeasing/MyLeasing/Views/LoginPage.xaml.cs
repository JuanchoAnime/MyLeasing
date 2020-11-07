namespace MyLeasing.Views
{
    using MyLeasing.Helpers;
    using Xamarin.Forms;

    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Translate();
        }

        private void Translate()
        {
            txtEmail.Placeholder = Languages.EnterEmail;
            txtPassword.Placeholder = Languages.EnterPassword;
            lblEmail.Text = Languages.EmailPlaceHolder;
            lblPassword.Text = Languages.PasswordPlaceHolder;
            btnLogin.Text = Languages.Login;
        }
    }
}
