using MobileClient.Services.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class CompareAttribute : Attribute
    {
        protected string targetPropertyName;

        public CompareAttribute(string targetPropertyName)
        {
            this.targetPropertyName = targetPropertyName;
        }
    }
}
