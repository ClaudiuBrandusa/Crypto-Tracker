using MobileClient.Services.Navigation;
using MobileClient.ViewModels.Authorized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Authorized
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletView : ContentPage
    {
        public WalletView()
        {
            InitializeComponent();
            BindingContext = new WalletViewModel(DependencyService.Get<INavigationService>());
        }
    }
}