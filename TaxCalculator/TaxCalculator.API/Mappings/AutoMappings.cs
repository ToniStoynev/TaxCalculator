using AutoMapper;
using TaxCalculator.Models.RequestModels;
using TaxCalculator.Models.ResponseModels;
using TaxCalculator.Services.Models;

namespace TaxCalculator.Mappings
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<TaxPayerModel, TaxPayerServiceModel>();
            CreateMap<TaxesServiceModel, TaxesModel>();
        }
    }
}
