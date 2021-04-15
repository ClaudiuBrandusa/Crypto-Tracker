using MobileClient.Services.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LengthConstraintAttribute : Attribute, IValidator
    {
        private string thisPropertyName;
        private int minLength;
        private int maxLength;
        private string content;
        private string message = "";

        public LengthConstraintAttribute(int minLength = 0, int maxLength = 0, [CallerMemberName] string thisPropertyName = null)
        {
            this.thisPropertyName = thisPropertyName;

            if(minLength == 0)
            {
                this.minLength = 0; // then we will ignore this constraint
            } else if(minLength < 1)
            {
                this.minLength = 1;
            } else
            {
                this.minLength = minLength;
            }
            if(maxLength == 0)
            {
                this.maxLength = 0; // then we will ignore this constraint
            } else if(maxLength < 1)
            {
                this.maxLength = 1;
            } else if(this.minLength != 0 && maxLength < this.minLength)
            {
                this.maxLength = this.minLength + 1;
            }
        }

        public string Message => message;

        public bool Check(object[] values)
        {
            if(values.Length == 1 && values[0] is string)
            {
                content = values[0].ToString();

                if(minLength != 0 && content.Length < minLength)
                {
                    message = $"Length has to be at least {minLength.ToString()}";
                    return false;
                }
                if(maxLength != 0 && content.Length > maxLength)
                {
                    message = $"Length has to be less than {maxLength.ToString()}";
                    return false;
                }
                return true;
            }

            return false;
        }

        public string[] GetNeededPropertiesName() => new string[] { thisPropertyName };
    }
}
