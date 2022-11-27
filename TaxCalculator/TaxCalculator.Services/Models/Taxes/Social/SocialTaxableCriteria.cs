using TaxCalculator.Domain.Models.Taxes;

namespace TaxCalculator.Services.Models.Taxes.Social
{
    public class SocialTaxableCriteria : ITaxableCriteria
    {
        public TaxableCriteria GetRate()
        {
            return new TaxableCriteria(15, 1000, 3000);
        }
    }
}
