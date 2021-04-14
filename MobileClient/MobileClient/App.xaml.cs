﻿using MobileClient.Models;
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

        public App()
        {
            InitializeComponent();

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
            navigationService.NavigateTo(new LoginViewModel(navigationService), true);
        }

        public void ResetMainPage()
        {
            MainPage = new NavigationPage();
        }
    }
}
