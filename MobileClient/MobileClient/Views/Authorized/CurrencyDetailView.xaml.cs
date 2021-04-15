using MobileClient.Models;
using MobileClient.Services.Navigation;
using MobileClient.ViewModels.Authorized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Authorized
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrencyDetailView : ContentPage
    {
        public CurrencyDetailView()
        {
            InitializeComponent();
        }

        public CurrencyDetailView(CurrencyModel model)
        {
            InitializeComponent();
            ((NavigationPage)App.Current.MainPage).BarBackgroundColor = (Color) App.Current.Resources["primaryColor"];
        }
    }
}