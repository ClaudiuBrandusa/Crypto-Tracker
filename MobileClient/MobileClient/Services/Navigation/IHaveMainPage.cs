using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.Services.Navigation
{
    public interface IHaveMainPage
    {
        Page MainPage { get; set; }
    }
}
