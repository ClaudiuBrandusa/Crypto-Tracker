using MobileClient.Services.Navigation;
using MobileClient.Services.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace MobileClient.ViewModels
{
    public class BaseValidationViewModel : BaseViewModel
    {
        private Dictionary<string, ObservableCollection<string>> _errors;

        public Dictionary<string, ObservableCollection<string>> Errors // the key will be the property's name
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }

        private Dictionary<string, List<IValidator>> _validators = new Dictionary<string, List<IValidator>>();

        public BaseValidationViewModel(INavigationService navService) : base(navService)
        {
            Errors = new Dictionary<string, ObservableCollection<string>>();
        }

        protected void InitValidators(object model)
        {
            foreach(PropertyInfo property in model.GetType().GetProperties())
            {
                var list = (Attribute.GetCustomAttributes(property, typeof(Attribute))).Where(c => c is IValidator).Select(c => c as IValidator).ToList();
                foreach (IValidator validator in list)
                {
                    AddValidator(property.Name, validator);
                }
            }
        }

        protected bool Validate()
        {
            ClearErrors();

            bool status = true;

            foreach (string propertyName in _validators.Keys)
            {

                if (!Validate(propertyName))
                {
                    status = false;
                }
            }

            if(status) // if everything went ok
            {
                HideErrors();
            }

            return status;
        }

        private object GetValueByProperty(string propertyName)
        {
            return GetType().GetProperty(propertyName)?.GetValue(this);
        }

        private object[] GetNeededValues(IValidator validator)
        {
            string[] neededPropertiesName = validator.GetNeededPropertiesName();
            object[] values = new object[neededPropertiesName.Length];

            for (int i = 0; i < values.Length; i++)
            {
                if (neededPropertiesName[i] == null || !(neededPropertiesName[i] is string))
                {
                    continue;
                }
                values[i] = GetValueByProperty(neededPropertiesName[i]);
            }

            return values;
        }

        protected bool Validate(string propertyName)
        {
            bool status = true;

            foreach(IValidator validator in _validators[propertyName])
            {
                if(!validator.Check(GetNeededValues(validator)))
                {
                    status = false;
                    ShowError(propertyName, validator.Message);
                }
            }

            return status;
        }

        private void RefreshErrors()
        {
            var aux = Errors;
            _errors = null;
            Errors = aux;
        }

        private void ShowError(string propertyName, string errorMessage)
        {
            if(AddError(propertyName, errorMessage))
            {
                RefreshErrors();
            } // otherwise the error is already shown
        }

        protected void ClearErrors()
        {
            HideErrors();
        }

        private void HideErrorFor(string propertyName)
        {
            if(RemoveErrorFor(propertyName))
            {
                RefreshErrors();
            }
        }

        private void HideErrors()
        {
            string errorName = "";
            while(Errors.Keys.Count > 0)
            {
                errorName = Errors.Keys.First();
                HideErrorFor(errorName);
            }

            if(!string.IsNullOrEmpty(errorName))
            {
                RefreshErrors();
            }
        }

        private void AddValidator(string propertyName, IValidator validator)
        {
            if(_validators.ContainsKey(propertyName))
            {
                if(_validators[propertyName].Contains(validator))
                {
                    return;
                }

                _validators[propertyName].Add(validator);

                return;
            }

            _validators.Add(propertyName, new List<IValidator>() { validator });
        }

        private bool AddError(string propertyName, string errorMessage)
        {
            if(Errors.ContainsKey(propertyName))
            {
                if(Errors[propertyName].Contains(errorMessage))
                {
                    return false;
                }

                Errors[propertyName].Add(errorMessage);
                return true;
            }

            Errors.Add(propertyName, new ObservableCollection<string>() { errorMessage });

            return true;
        }

        private bool RemoveErrorFor(string propertyName)
        {
            if(Errors.ContainsKey(propertyName))
            {
                Errors.Remove(propertyName);
                return true;
            }

            return false;
        }
    }
}
