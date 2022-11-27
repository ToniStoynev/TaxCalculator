using TaxCalculator.Domain.Models.Taxes;

namespace TaxCalculator.Services.Models.Taxes.Social
{
    public class SocialTaxablePolicy : TaxablePolicy
    {
        public SocialTaxablePolicy(ITaxableCriteria taxableCriteria)
            :base(taxableCriteria)
        {}

        protected override decimal CalculateTaxAmount(TaxableIncome income, TaxableCriteria rate)
        {
            decimal maxTaxableAmount = rate.MaxThreshold - rate.MinThreshold;
            decimal taxableAmount;

            if (income.GrossIncome > rate.MaxThreshold)
            {
                taxableAmount = maxTaxableAmount;
            }
            else
            {
                taxableAmount = income.GrossIncome - rate.MinThreshold;
            }

            return (rate.Rate / 100) * taxableAmount;
        }
    }
}
