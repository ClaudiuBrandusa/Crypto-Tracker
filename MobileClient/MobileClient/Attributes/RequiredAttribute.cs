using MobileClient.Services.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute, IValidator
    {
        private string thisPropertyName;

        public RequiredAttribute([CallerMemberName] string thisPropertyName = null)
        {
            this.thisPropertyName = thisPropertyName;
        }

        public string Message { get => "This field is required"; }

        public bool Check(object[] values)
        {
            return values.Length == 1 && values[0] != null;
        }

        public string[] GetNeededPropertiesName() => new string[] { thisPropertyName };
    }
}
