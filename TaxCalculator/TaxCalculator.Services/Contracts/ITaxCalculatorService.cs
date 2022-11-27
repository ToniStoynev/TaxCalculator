using TaxCalculator.Services.Models;

namespace TaxCalculator.Services.Contracts
{
    public interface ITaxCalculatorService
    {
        TaxesServiceModel CalculateTaxes(TaxPayerServiceModel taxPayerServiceModel);
    }
}
