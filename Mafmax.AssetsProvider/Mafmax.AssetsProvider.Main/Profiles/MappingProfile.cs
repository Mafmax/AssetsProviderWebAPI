using AutoMapper;
using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.DAL.Entities;

namespace Mafmax.AssetsProvider.Main.Profiles
{
    /// <summary>
    /// Provides automapper configuration
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Create profile
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Asset, ShortAssetDto>()
                .ForMember(dest => dest.ExchangeStockCode, opt => opt.MapFrom(src => src.Stock.Key))
                .ForMember(dest => dest.IssuerName, opt => opt.MapFrom(src => src.Issuer.Name));

            CreateMap<Issuer, IssuerDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry.Name));

            CreateMap<CirculationPeriod, CirculationPeriodDto>();

            CreateMap<StockExchange, StockExchangeDto>();

            CreateMap<Asset, AssetDto>();
        }
    }
}
