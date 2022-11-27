using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using System.Threading.Tasks;
using TaxCalculator.Models.RequestModels;
using TaxCalculator.Models.ResponseModels;
using TaxCalculator.Services.Contracts;
using TaxCalculator.Services.Models;

namespace TaxCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private IValidator<TaxPayerModel> _validator;
        IMemoryCache _cache;
        private readonly ITaxCalculatorService _taxCalculatorService;
        private IMapper _mapper;

        public CalculatorController(IValidator<TaxPayerModel> validator,
            IMemoryCache cache,
            ITaxCalculatorService taxCalculatorService,
            IMapper mapper)
        {
            _validator = validator;
            _cache = cache;
            _taxCalculatorService = taxCalculatorService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(TaxPayerModel taxPayerModel, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(taxPayerModel, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (_cache.TryGetValue(taxPayerModel.SSN, out TaxesModel cachedTaxes))
            {
                return Ok(cachedTaxes);
            }

            var taxPayerServiceModel = _mapper.Map<TaxPayerServiceModel>(taxPayerModel);

            var taxes = _mapper.Map<TaxesModel>(_taxCalculatorService
                .CalculateTaxes(taxPayerServiceModel));

            _cache.Set(taxPayerModel.SSN, taxes);

            return Ok(taxes);
        }
    }
}
