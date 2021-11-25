using MobileClient.Models;
using MobileClient.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.ViewModels.Authorized
{
    public class CurrencyDetailViewModel : BaseViewModel
    {
        public CurrencyModel Model { get; }

        public CurrencyDetailViewModel(INavigationService navigation) : base(navigation)
        {
            Model = new CurrencyModel { Name = "a", Price = 10, PriceChange = 30};
        }
    }
}
