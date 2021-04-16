using MobileClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Services.Identity
{
    public interface IRegisterService
    {
        Task<bool> Register(RegisterModel model);
    }
}
