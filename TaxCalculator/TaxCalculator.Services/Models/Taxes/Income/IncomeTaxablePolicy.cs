using TaxCalculator.Domain.Models.Taxes;

namespace TaxCalculator.Services.Models.Taxes.Income
{
    public class IncomeTaxablePolicy : TaxablePolicy
    {
        public IncomeTaxablePolicy(ITaxableCriteria taxableCriteria)
            : base(taxableCriteria)
        {}

        protected override decimal CalculateTaxAmount(TaxableIncome income, TaxableCriteria rate)
        {
           return (rate.Rate / 100) * (income.GrossIncome - rate.MinThreshold);
        }
    }
}
