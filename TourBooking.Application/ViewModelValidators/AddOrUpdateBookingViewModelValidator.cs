using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Application.ViewModels;

namespace TourBooking.Application.ViewModelValidators
{
    public class AddOrUpdateBookingViewModelValidator: AbstractValidator<AddOrUpdateBookingViewModel>
    {
        public AddOrUpdateBookingViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotEmpty().Must(IsDigitsOnly)
                .WithMessage("price value is not valid.it may contains charachters other than 0-9")
                .Must(NotStartWithZero)
                .WithMessage("Price mustn't start with zero");
        }
        private  bool IsDigitsOnly(string str)
        {
            return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
        }
        private bool NotStartWithZero(string str)
        {
            return !string.IsNullOrEmpty(str) && !str.StartsWith('0');
        }
    }
}
