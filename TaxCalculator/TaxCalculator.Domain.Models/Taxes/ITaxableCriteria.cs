namespace TaxCalculator.Domain.Models.Taxes
{
    public interface ITaxableCriteria
    {
        TaxableCriteria GetRate();
    }
}
