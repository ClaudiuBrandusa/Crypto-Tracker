using MobileClient.Services.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MobileClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : RegularExpressionAttribute, IValidator
    {
        private string thisPropertyName;

        public EmailAttribute([CallerMemberName] string thisPropertyName = null) : base(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}")
        {
            this.thisPropertyName = thisPropertyName;

            ErrorMessage = "Please provide a valid email address";
        }

        public string Message { get => ErrorMessage; }

        public bool Check(object[] values)
        {
            return values.Length == 1 && values[0] != null && IsValid(values[0]);
        }

        public string[] GetNeededPropertiesName() => new string[] { thisPropertyName };
    }
}
