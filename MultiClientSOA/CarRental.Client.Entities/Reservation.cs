using Core.Common.Core;
using System;

namespace CarRental.Client.Entities
{
    public class Reservation : ObjectBase
    {

        int _ReservationId;

        int _AccountId;

        int _CarId;

        DateTime _RentalDate;

        DateTime _ReturnDate;

        public int ReservationId
        {
            get => _ReservationId;
            set
            {
                if (_ReservationId != value)
                {
                    _ReservationId = value;
                    OnPropertyChanged(() => ReservationId);
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
        public DateTime RentalDate
        {
            get => _RentalDate;
            set
            {
                if (_RentalDate != value)
                {
                    _RentalDate = value;
                    OnPropertyChanged(() => RentalDate);
                }
                Validate();
            }
        }
        public DateTime ReturnDate
        {
            get => _ReturnDate;
            set
            {
                if (_ReturnDate != value)
                {
                    _ReturnDate = value;
                    OnPropertyChanged(() => ReturnDate);
                }
                Validate();
            }
        }
    }
}
