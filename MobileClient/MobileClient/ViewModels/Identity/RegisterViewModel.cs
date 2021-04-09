using MobileClient.Services.Navigation;
using MobileClient.Views.Authorized;
using MobileClient.Views.Identity;
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
            App.ChangeView(new LoginView());
        }

        void OnRegisterCommand()
        {
            App.ChangeView(new NavigationPage(new TabbedPageView()));
        }
    }
}
