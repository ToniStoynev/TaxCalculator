using FluentValidation;
using System;

namespace TaxCalculator.Models.RequestModels
{
    public class TaxPayerModel
    {
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string SSN { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal CharitySpent { get; set; }
    }

    public class TaxPayerValidator : AbstractValidator<TaxPayerModel>
    {
        public TaxPayerValidator()
        {
            RuleFor(x => x.FullName)
                .NotNull().WithMessage("Please ensure that to set a value for { PropertyName}")
                .NotEmpty().WithMessage("Please ensure that to set a value for { PropertyName}")
                .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters.");

            RuleFor(x => x.SSN)
                .Matches(@"^[0-9]*$").WithMessage("SSN must contain only digits")
                .Length(5, 10).WithMessage("SSN length must be between 5 and 10 digits");

            RuleFor(x => x.GrossIncome)
                .GreaterThan(0);

            RuleFor(x => x.CharitySpent)
                .GreaterThanOrEqualTo(0);
        }
    }
}
