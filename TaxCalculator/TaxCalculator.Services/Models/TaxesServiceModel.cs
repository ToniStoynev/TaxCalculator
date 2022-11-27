namespace TaxCalculator.Services.Models
{
    public class TaxesServiceModel
    {
        public decimal GrossIncome { get; set; }

        public decimal CharitySpent { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal SocialTax { get; set; }

        public decimal TotalTax { get; set; }

        public decimal NetIncome => GrossIncome - TotalTax;

        public TaxesServiceModel()
        {
        }

        public TaxesServiceModel(decimal grossIncome,
            decimal charitySpent,
            decimal incomeTax,
            decimal socialTax,
            decimal totalTax)
        {
            GrossIncome = grossIncome;
            CharitySpent = charitySpent;
            IncomeTax = incomeTax;
            SocialTax = socialTax;
            TotalTax = totalTax;
        }
    }
}
