namespace TaxCalculator.Domain.Models.Taxes
{
    public abstract class TaxablePolicy : ITaxablePolicy<TaxableIncome>
    {
        private readonly ITaxableCriteria _taxableCriteria;

        protected TaxablePolicy(ITaxableCriteria taxableCriteria)
        {
            _taxableCriteria = taxableCriteria;
        }

        public decimal CalculateTax(TaxableIncome income)
        {
            if (!IsSatisfied(income))
            {
                return 0;
            }

            var rate = _taxableCriteria.GetRate();

            return CalculateTaxAmount(income, rate);
        }

        public virtual bool IsSatisfied(TaxableIncome income)
        {
            if (income.GrossIncome < 0)
            {
                return false;
            }

            var rate = _taxableCriteria.GetRate();

            return income.GrossIncome > rate.MinThreshold;
        }

        protected abstract decimal CalculateTaxAmount(TaxableIncome income, TaxableCriteria rate);
    }
}
