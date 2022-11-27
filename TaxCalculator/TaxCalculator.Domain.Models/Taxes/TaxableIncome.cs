namespace TaxCalculator.Domain.Models.Taxes
{
    public class TaxableIncome
    {
        public decimal GrossIncome { get; private set; }

        public TaxableIncome(decimal grossIncome)
        {
            GrossIncome = grossIncome;
        }
    }
}
