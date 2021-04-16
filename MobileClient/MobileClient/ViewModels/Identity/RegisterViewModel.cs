using MobileClient.Models;
using MobileClient.Services.Identity;
using MobileClient.Services.Navigation;
using MobileClient.ViewModels.Authorized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Identity
{
    public class RegisterViewModel : BaseValidationViewModel
    {
        public new Dictionary<string, ObservableCollection<string>> Errors
        {
            get => base.Errors;
            set => base.Errors = value;
        }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        RegisterModel model;

        public string Username
        {
            get { return model.Username; }
            set
            {
                model.Username = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return model.Email; }
            set
            {
                model.Email = value;
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

        public string ConfirmPassword
        {
            get { return model.ConfirmPassword; }
            set
            {
                model.ConfirmPassword = value;
                OnPropertyChanged();
            }
        }

        public RegisterViewModel(INavigationService navigation) : base(navigation)
        {
            model = new RegisterModel();
            LoginCommand = new Command(OnLoginCommand);
            RegisterCommand = new Command(OnRegisterCommand);
            InitValidators(model);
        }

        async void OnLoginCommand()
        {
            await navigation.NavigateTo(new LoginViewModel(navigation), true);
        }

        async void OnRegisterCommand()
        {
            if(!Validate())
            {
                return;
            }

            bool status = false;

            status = await DependencyService.Get<IRegisterService>().Register(model);

            if(!status)
            {
                // alert the client that the registration process failed
                return;
            }

            await navigation.NavigateTo(new TabbedPageViewModel(navigation), true);
        }
    }
}
