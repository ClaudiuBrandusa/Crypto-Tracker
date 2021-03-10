using MobileClient.ViewModels.Authorized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrenciesView : ContentPage
    {
        public CurrenciesView()
        {
            InitializeComponent();
            BindingContext = new CurrenciesViewModel(Navigation);
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionView collection = sender as CollectionView;

            collection.SelectedItem = null;
        }
    }
}