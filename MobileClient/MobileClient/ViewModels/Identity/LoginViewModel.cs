using MobileClient.Services.Navigation;
using MobileClient.ViewModels.Authorized;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Identity
{
    public class LoginViewModel : BaseViewModel
    {

        public Command RegisterCommand { get; }
        public Command LoginCommand { get; }

        string username;
        public string Username { 
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
        }

        async void OnRegisterCommand()
        {
            await navigation.NavigateTo(new RegisterViewModel(navigation), true);
        }

        async void OnLoginCommand()
        {
            await navigation.NavigateTo(new TabbedPageViewModel(navigation), true);
        }

        // Validation

        bool Validate()
        {
            return ValidateUsername() && ValidatePassword();
        }

        bool ValidateUsername()
        {
            return true;
        }

        bool ValidatePassword()
        {
            return true;
        }
    }
}
