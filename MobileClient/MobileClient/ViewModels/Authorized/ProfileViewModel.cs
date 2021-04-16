using MobileClient.Services.Identity;
using MobileClient.Services.Navigation;
using MobileClient.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Authorized
{
    public class ProfileViewModel : BaseViewModel
    {
        public Command LogoutCommand { get; }
        public ProfileViewModel(INavigationService navigation) : base(navigation)
        {
            LogoutCommand = new Command(Logout);
        }

        private async void Logout()
        {
            if(!await DependencyService.Get<ILoginService>().Logout())
            {
                // something went wrong
                return;
            }

            await navigation.NavigateTo(new LoginViewModel(navigation), true);
        }
    }
}
