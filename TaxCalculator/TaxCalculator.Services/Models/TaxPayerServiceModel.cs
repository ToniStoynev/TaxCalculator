using System;

namespace TaxCalculator.Services.Models
{
    public class TaxPayerServiceModel
    {
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string SSN { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal CharitySpent { get; set; }
    }
}
