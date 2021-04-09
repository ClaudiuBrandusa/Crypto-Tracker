using MobileClient.Models;
using MobileClient.Services.Navigation;
using MobileClient.Services.ViewLocator;
using MobileClient.ViewModels.Identity;
using MobileClient.Views;
using MobileClient.Views.Identity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient
{
    public partial class App : Application, IHaveMainPage
    {
        public User CurrentUser { get; set; }

        INavigationService navigationService;

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginView());
            MainPage = new NavigationPage();

            CurrentUser = new User();
            
            navigationService = new NavigationService(this, new ViewLocator());
            DependencyService.RegisterSingleton(navigationService);

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
            MainPage = new LoginView();
        }
    
        public static void ChangeView(Page page)
        {
            App.Current.MainPage = page;
        }
    }
}
