namespace SaibaMais.API.Estoque.Application.Interfaces
{
    using SaibaMais.API.Estoque.Application.ViewModels;
    using SaibaMais.API.Estoque.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInventoryService
    {
        //Task<List<ApiResponseViewModel>> getInventory(string CustomHeader);

        Task<ApiResponseViewModel> GetVehicleDetails(string chassiVeiculo);
        Task<ApiResponse> GetInventory(FiltroEstoque filtroEstoque);
        Task<ApiResponse> GetDetailedInventory(FiltroDetailedInventory filtroDetailed);
        FiltrosParams GetFiltroParams();
    }
}
