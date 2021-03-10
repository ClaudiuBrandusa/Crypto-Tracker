using MobileClient.Models;
using MobileClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.ViewModels.Authorized
{
    public class CurrenciesViewModel : BaseViewModel
    {
        public ObservableCollection<CurrencyModel> Currencies { get; }

        CurrencyModel _selectedCurrency;

        public CurrencyModel SelectedCurrency 
        { 
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;
                if (value == null) return;
                navigation.PushAsync(new CurrencyDetailView(value));
            }
        }

        public CurrenciesViewModel(INavigation navigation = null) : base(navigation)
        {
            Currencies = new ObservableCollection<CurrencyModel>
            {
                new CurrencyModel
                {
                    Name = "KitCoin",
                    Price = 1.3f
                },

                new CurrencyModel
                {
                    Name = "CheapCoin",
                    Price = .146f
                },

                new CurrencyModel
                {
                    Name = "Koin",
                    Price = 6.7f
                },

                new CurrencyModel
                {
                    Name = "Ko!n",
                    Price = 13.9f
                },

                new CurrencyModel
                {
                    Name = "TheRealCoin",
                    Price = 0.01f
                },

                new CurrencyModel
                {
                    Name = "FakeCoin",
                    Price = .9f
                }
            };
        }
    }
}
