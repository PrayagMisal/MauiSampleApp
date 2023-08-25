using AndroidX.Annotations;

namespace MauiSampleApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                SetField(ref _userName, value);
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetField(ref _password, value);
            }
        }

        public Command SignUpCommand { get; }
        public Command LoginCommand { get; }
        public Command SignInLoginWithFacebookCommand { get; }
        public Command<Entry> UserNameDoneCommand { get; }

        public LoginViewModel()
        {
            SignUpCommand = new Command(SignUpCommandMethod);
            LoginCommand = new Command(LoginCommandMethod);
            SignInLoginWithFacebookCommand = new Command(SignInLoginWithFacebookCommandMethod);
            UserNameDoneCommand = new Command<Entry>(UserNameDoneCommandMethod);
        }

        private void SignUpCommandMethod()
        {

        }
        private void LoginCommandMethod()
        {

        }
        private void SignInLoginWithFacebookCommandMethod()
        {

        }
        private void UserNameDoneCommandMethod(Entry passwordEntry)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                try
                {
                    if (passwordEntry is not null)
                        passwordEntry.Focus();
                }
                catch (Exception exc)
                {

                }
            });
        }
    }
}