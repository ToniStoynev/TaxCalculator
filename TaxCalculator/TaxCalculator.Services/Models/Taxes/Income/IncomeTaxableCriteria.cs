using TaxCalculator.Domain.Models.Taxes;

namespace TaxCalculator.Services.Models.Taxes.Income
{
    public class IncomeTaxableCriteria : ITaxableCriteria
    {
        public TaxableCriteria GetRate()
        {
            return new TaxableCriteria(10, 1000, decimal.MaxValue);
        }
    }
}
