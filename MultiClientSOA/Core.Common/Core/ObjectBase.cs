using Core.Common.Utils;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Common.Core
{
    public class ObjectBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler _PropertyChanged;

        List<PropertyChangedEventHandler> _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();
        bool _IsDirty = false;
        protected IValidator _Validator = null;

        protected IEnumerable<ValidationFailure> _ValidationErrors = null;



        public ObjectBase()
        {
            _Validator = GetValidator();
            Validate();
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!_PropertyChangedSubscribers.Contains(value))
                {
                    _PropertyChanged += value;
                    _PropertyChangedSubscribers.Add(value);
                }
            }

            remove
            {
                _PropertyChanged -= value;
                _PropertyChangedSubscribers.Remove(value);
            }
        }

        protected virtual IValidator GetValidator()
        {
            return null;
        }

        public void Validate()
        {
            if (_Validator != null)
            {
                var results = _Validator.Validate(this);
                _ValidationErrors = results.Errors;
            }
        }

        public virtual bool IsValid
        {
            get
            {
                if (_ValidationErrors != null && _ValidationErrors.Count() > 0)
                    return false;
                else
                    return true;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            if (_PropertyChanged != null)
                _PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (makeDirty)
                _IsDirty = true;

        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }



        public bool IsDirty { get => _IsDirty; set => _IsDirty = value; }
    }
}
