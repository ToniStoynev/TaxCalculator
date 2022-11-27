using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Domain.Models.Taxes;
using TaxCalculator.Services.Contracts;
using TaxCalculator.Services.Models;
using TaxCalculator.Services.Models.Taxes.Income;
using TaxCalculator.Services.Models.Taxes.Social;

namespace TaxCalculator.Services.Implementations
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly IEnumerable<ITaxablePolicy<TaxableIncome>> _taxPolicies;

        public TaxCalculatorService()
        {
            _taxPolicies = new List<ITaxablePolicy<TaxableIncome>>
            {
                 new IncomeTaxablePolicy(new IncomeTaxableCriteria()),
                 new SocialTaxablePolicy(new SocialTaxableCriteria())
            };
        }

        public TaxesServiceModel CalculateTaxes(TaxPayerServiceModel taxPayerServiceModel)
        {
            if (taxPayerServiceModel is null || taxPayerServiceModel.GrossIncome <= 0)
            {
                return new TaxesServiceModel();
            }

            var taxIncome = CalculateTaxableIncome(taxPayerServiceModel.GrossIncome, taxPayerServiceModel.CharitySpent);

            var applicableTaxPolicies = _taxPolicies.Where(tp => tp.IsSatisfied(taxIncome));

            var incomeTax = _taxPolicies
                    .FirstOrDefault(tp => tp.GetType() == typeof(IncomeTaxablePolicy))
                    .CalculateTax(taxIncome);

            var socialTax = _taxPolicies
                    .FirstOrDefault(tp => tp.GetType() == typeof(SocialTaxablePolicy))
                    .CalculateTax(taxIncome);

            var totalTax = applicableTaxPolicies.Sum(x => x.CalculateTax(taxIncome));

            return new TaxesServiceModel(taxPayerServiceModel.GrossIncome,
                taxPayerServiceModel.CharitySpent,
                incomeTax,
                socialTax,
                totalTax);
        }

        private TaxableIncome CalculateTaxableIncome(decimal grossIncome, decimal charitySpent)
        {
            if (charitySpent == 0.0m)
            {
                return new TaxableIncome(grossIncome);
            }

            var maxAllowedCharitySpent = 0.1m * grossIncome;

            return charitySpent > maxAllowedCharitySpent
                ? new TaxableIncome(grossIncome - maxAllowedCharitySpent)
                : new TaxableIncome(grossIncome - charitySpent);
        }
    }
}
