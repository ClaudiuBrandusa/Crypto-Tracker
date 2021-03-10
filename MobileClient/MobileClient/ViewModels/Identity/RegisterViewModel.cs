using MobileClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Identity
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public RegisterViewModel()
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
