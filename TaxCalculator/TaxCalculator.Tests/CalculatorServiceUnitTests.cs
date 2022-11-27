using TaxCalculator.Services.Contracts;
using TaxCalculator.Services.Implementations;
using TaxCalculator.Services.Models;
using Xunit;

namespace TaxCalculator.Services.Tests
{
    public class CalculatorServiceUnitTests
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        public CalculatorServiceUnitTests()
        {
            _taxCalculatorService = new TaxCalculatorService();
        }

        [Fact]
        public void ReturnZeroTaxesForGivenZeroAmount()
        {
            var taxPayerServiceModel = new TaxPayerServiceModel();

            var result = _taxCalculatorService.CalculateTaxes(taxPayerServiceModel);

            Assert.True(result.TotalTax == 0);
        }

        [Fact]
        public void ReturnTaxAmountEquals980()
        {
            var expectedGrossIncome = 980;
            var taxPayerServiceModel = new TaxPayerServiceModel() { GrossIncome = expectedGrossIncome };
            var result = _taxCalculatorService.CalculateTaxes(taxPayerServiceModel);
            Assert.True(result.GrossIncome == expectedGrossIncome);
        }

        [Fact]
        public void ReturnTotalTaxAmountEquals524()
        {
            var expectedIncomeTax = 224;
            var expectedSocialContributions = 300;
            var expectedTotalTax = 524;
            var expectedNetIncome = 3076;

            var taxPayerServiceModel = new TaxPayerServiceModel() { GrossIncome = 3600, CharitySpent = 520 };
            var result = _taxCalculatorService.CalculateTaxes(taxPayerServiceModel);

            Assert.True(result.IncomeTax == expectedIncomeTax);
            Assert.True(result.SocialTax == expectedSocialContributions);
            Assert.True(result.NetIncome == expectedNetIncome);
        }
    }
}
