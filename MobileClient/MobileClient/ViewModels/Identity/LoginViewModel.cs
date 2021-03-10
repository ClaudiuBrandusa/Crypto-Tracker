using MobileClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Identity
{
    public class LoginViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }
        public Command LoginCommand { get; }

        public LoginViewModel()
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
            App.ChangeView(new NavigationPage(new TabbedPageView()));
        }
    }
}
