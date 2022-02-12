namespace SaibaMais.API.Estoque.Services.Configuration
{
    using AutoMapper;
    using SaibaMais.API.Estoque.Application.ViewModels;
    using SaibaMais.API.Estoque.Domain.ADO;
    using SaibaMais.API.Estoque.Domain.Entities;

    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region [Inventory]

            CreateMap<ApiResponseViewModel, ApiResponse>().ReverseMap();
            CreateMap<ApiResponse, ApiResponseADO>().ReverseMap();

            #endregion
        }
    }
}
