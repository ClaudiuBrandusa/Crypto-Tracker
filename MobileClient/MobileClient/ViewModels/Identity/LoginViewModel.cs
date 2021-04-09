using MobileClient.Services.Navigation;
using MobileClient.Views.Authorized;
using MobileClient.Views.Identity;
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

        /*public bool ButtonVisibility
        {
            get { }
        }*/

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
        }

        void OnRegisterCommand()
        {
            App.ChangeView(new RegisterView());

        }

        void OnLoginCommand()
        {
            navigation.NavigateTo(DependencyService.Get<TabbedPageViewModel>(), true);
            App.ChangeView(new NavigationPage(new TabbedPageView()));
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

        /*public override Task Init(LoginModel parameter)
        {
            Username = "";
            Password = "";
            return Task.CompletedTask;
        }*/
    }
}
