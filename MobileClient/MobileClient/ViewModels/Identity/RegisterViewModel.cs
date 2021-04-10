using MobileClient.Services.Navigation;
using MobileClient.ViewModels.Authorized;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Identity
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public RegisterViewModel(INavigationService navigation) : base(navigation)
        {
            LoginCommand = new Command(OnLoginCommand);
            RegisterCommand = new Command(OnRegisterCommand);
        }

        void OnLoginCommand()
        {
            navigation.NavigateTo(new LoginViewModel(navigation), true);
        }

        void OnRegisterCommand()
        {
            navigation.NavigateTo(new TabbedPageViewModel(navigation), true);
        }
    }
}
