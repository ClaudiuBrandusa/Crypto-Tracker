using MobileClient.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();

            
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
