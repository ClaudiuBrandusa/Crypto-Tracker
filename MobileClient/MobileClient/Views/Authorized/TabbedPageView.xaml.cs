using MobileClient.Services.Navigation;
using MobileClient.ViewModels;
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
    public partial class TabbedPageView : TabbedPage
    {
        public TabbedPageView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new TabbedPageViewModel(DependencyService.Get<INavigationService>());
        }
    }
}