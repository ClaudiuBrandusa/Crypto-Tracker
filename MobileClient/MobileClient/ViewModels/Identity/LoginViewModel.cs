using MobileClient.Models;
using MobileClient.Services.Identity;
using MobileClient.Services.Navigation;
using MobileClient.ViewModels.Authorized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Identity
{
    public class LoginViewModel : BaseValidationViewModel
    {
        public new Dictionary<string, ObservableCollection<string>> Errors
        {
            get => base.Errors;
            set => base.Errors = value;
        }

        public Command RegisterCommand { get; }
        public Command LoginCommand { get; }

        LoginModel model;

        public string Username { 
            get { return model.Username; }
            set
            {
                model.Username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return model.Password; }
            set
            {
                model.Password = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            model = new LoginModel();
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
            InitValidators(model);
        }

        async void OnRegisterCommand()
        {
            await navigation.NavigateTo(new RegisterViewModel(navigation), true);
        }

        async void OnLoginCommand()
        {
            if(!Validate())
            {
                return;
            }

            bool status = await DependencyService.Get<ILoginService>().Login(model);
            if(!status)
            {
                // alert the client that the login process failed
                return;
            }

            await navigation.NavigateTo(new TabbedPageViewModel(navigation), true);
        }
    }
}
