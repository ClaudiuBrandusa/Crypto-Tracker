using MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.ViewModels.Authorized
{
    public class CurrencyDetailViewModel : BaseViewModel
    {
        public CurrencyModel Model { get; }

        public CurrencyDetailViewModel(CurrencyModel model)
        {
            Model = model;
        }
    }
}
