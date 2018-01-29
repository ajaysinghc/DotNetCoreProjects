using Core.Common.Core;
using System;

namespace CarRental.Client.Entities
{
    public class Account : ObjectBase
    {

        int _AccountId;

        string _LoginEmail;

        string _FirstName;

        string _LastName;

        string _Address;

        string _City;

        string _State;

        string _ZipCode;

        string _CreditCard;

        DateTime _ExpDate;

        public int AccountId
        {
            get => _AccountId;
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged(() => AccountId);
                }
                Validate();
            }
        }
        public string LoginEmail
        {
            get => _LoginEmail;
            set
            {
                if (_LoginEmail != value)
                {
                    _LoginEmail = value;
                    OnPropertyChanged(() => LoginEmail);
                }
                Validate();
            }
        }
        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
                Validate();
            }
        }
        public string LastName
        {
            get => _LastName;
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName);
                }
                Validate();
            }
        }
        public string Address
        {
            get => _Address;
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    OnPropertyChanged(() => Address);
                }
                Validate();
            }
        }
        public string City
        {
            get => _City;
            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged(() => City);
                }
                Validate();
            }
        }
        public string State
        {
            get => _State;
            set
            {
                if (_State != value)
                {
                    _State = value;
                    OnPropertyChanged(() => State);
                }
                Validate();
            }
        }
        public string ZipCode
        {
            get => _ZipCode;
            set
            {
                if (_ZipCode != value)
                {
                    _ZipCode = value;
                    OnPropertyChanged(() => ZipCode);
                }
                Validate();
            }
        }
        public DateTime ExpDate
        {
            get => _ExpDate;
            set
            {
                if (_ExpDate != value)
                {
                    _ExpDate = value;
                    OnPropertyChanged(() => ExpDate);
                }
                Validate();
            }
        }
    }
}
