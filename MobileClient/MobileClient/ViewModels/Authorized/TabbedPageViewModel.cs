﻿using MobileClient.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.ViewModels
{
    public class TabbedPageViewModel : BaseViewModel
    {

        public TabbedPageViewModel(INavigationService navigation) : base(navigation)
        {
        }
    }
}