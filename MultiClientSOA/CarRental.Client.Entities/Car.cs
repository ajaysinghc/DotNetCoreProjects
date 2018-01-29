using Core.Common.Core;
using FluentValidation;
using System;

namespace CarRental.Client.Entities
{
    public class Car : ObjectBase
    {

        int _CarId;

        string _Description;

        string _Color;

        int _Year;

        decimal _RentalPrice;

        bool _CurrentlyRented;

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
        public string Description
        {
            get => _Description;
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged(() => Description);
                }
                Validate();
            }
        }
        public string Color
        {
            get => _Color;
            set
            {
                if (_Color != value)
                {
                    _Color = value;
                    OnPropertyChanged(() => Color);
                }
                Validate();
            }
        }
        public int Year
        {
            get => _Year;
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                    OnPropertyChanged(() => Year);
                }
                Validate();
            }
        }
        public decimal RentalPrice
        {
            get => _RentalPrice;
            set
            {
                if (_RentalPrice != value)
                {
                    _RentalPrice = value;
                    OnPropertyChanged(() => RentalPrice);
                }
                Validate();
            }
        }
        public bool CurrentlyRented
        {
            get => _CurrentlyRented;
            set
            {
                if (_CurrentlyRented != value)
                {
                    _CurrentlyRented = value;
                    OnPropertyChanged(() => CurrentlyRented);
                }

                Validate();
            }
        }

        class CarValidator : AbstractValidator<Car>
        {
            public CarValidator()
            {
                RuleFor(obj => obj.Description).NotEmpty();
                RuleFor(obj => obj.CarId).NotEmpty();
                RuleFor(obj => obj.RentalPrice).GreaterThan(0);
                RuleFor(obj => obj.Year).GreaterThan(2000).LessThan(DateTime.Now.Year);
            }
        }

        protected override IValidator GetValidator()
        {
            return base.GetValidator();
        }

    }
}
