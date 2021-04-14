using MobileClient.Services.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CompareStringAttribute : CompareAttribute, IValidator
    {
        private string thisPropertyName;

        public CompareStringAttribute(string targetPropertyName, [CallerMemberName] string thisPropertyName = null) : base(targetPropertyName)
        {
            this.thisPropertyName = thisPropertyName;
        }

        public string Message => $"Must match with {targetPropertyName}";

        public bool Check(object[] values)
        {
            if(values == null)
            {
                return false;
            }

            if(values.Length != 2)
            {
                return false;
            }

            for(int i = 0; i < 2; i++)
            {
                if (values[i] == null || !(values[i] is string))
                    return false;
            }
        
            return values[0].ToString().Equals(values[1].ToString());
        }

        public string[] GetNeededPropertiesName() => new string[] { thisPropertyName, targetPropertyName };
    }
}
