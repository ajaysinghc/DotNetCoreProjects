using Core.Common.Core;
using System;

namespace CarRental.Client.Entities
{
    public class Rental : ObjectBase
    {
        int _RentalId;

        int _CarId;

        int _AccountId;

        DateTime _DateRented;

        DateTime? _DateReturned;

        DateTime _DateDue;

        public int RentalId
        {
            get => _RentalId;
            set
            {
                if (_RentalId != value)
                {
                    _RentalId = value;
                    OnPropertyChanged(() => RentalId);
                }
                Validate();
            }
        }

        public int CarId
        {
            get => _CarId;
            set
            {
                if (_CarId != value)
                {
                    _CarId = value;
                    OnPropertyChanged(() => CarId);
                }
                Validate();
            }
        }
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
        public DateTime DateRented
        {
            get => _DateRented;
            set
            {
                if (_DateRented != value)
                {
                    _DateRented = value;
                    OnPropertyChanged(() => DateRented);
                }
                Validate();
            }
        }
        public DateTime? DateReturned
        {
            get => _DateReturned;
            set
            {
                if (_DateReturned != value)
                {
                    _DateReturned = value;
                    OnPropertyChanged(() => DateReturned);
                }
                Validate();
            }
        }
        public DateTime DateDue
        {
            get => _DateDue;
            set
            {
                if (_DateDue != value)
                {
                    _DateDue = value;
                    OnPropertyChanged(() => DateDue);
                }
                Validate();
            }
        }
    }
}
