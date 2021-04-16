using MobileClient.Models;
using MobileClient.Services.Identity;
using MobileClient.Services.Identity.Token;
using MobileClient.Services.Navigation;
using MobileClient.Services.ViewLocator;
using MobileClient.ViewModels.Identity;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class App : Application, IHaveMainPage
    {
        public User CurrentUser { get; set; }

        INavigationService navigationService;

        ITokenProvider tokenProvider;

        IRegisterService registerService;
        ILoginService loginService;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage();

            CurrentUser = new User();

            InitDependencies();

            navigationService.NavigateTo(new LoginViewModel(navigationService), false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            navigationService.NavigateTo(new LoginViewModel(navigationService), true);
        }

        private void InitDependencies()
        {
            navigationService = new NavigationService(this, new ViewLocator());
            DependencyService.RegisterSingleton(navigationService);

            tokenProvider = new TokenProvider();
            DependencyService.Register<ITokenProvider, TokenProvider>();
            DependencyService.RegisterSingleton(tokenProvider);

            registerService = new RegisterService(tokenProvider);
            DependencyService.RegisterSingleton(registerService);

            loginService = new LoginService(tokenProvider);
            DependencyService.RegisterSingleton(loginService);
        }

        public void ResetMainPage()
        {
            MainPage = new NavigationPage();
        }
    }
}
