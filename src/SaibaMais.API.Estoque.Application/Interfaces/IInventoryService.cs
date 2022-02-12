namespace SaibaMais.API.Estoque.Application.Interfaces
{
    using SaibaMais.API.Estoque.Application.ViewModels;
    using SaibaMais.API.Estoque.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInventoryService
    {
        Task<ApiResponseViewModel> GetVehicleDetails(string chassiVeiculo);
        Task<List<Inventory>> GetInventory(FiltroEstoque filtroEstoque);
        Task<List<DetailedInventory>> GetDetailedInventory(FiltroDetailedInventory filtroDetailed);
        Task<FiltrosParams> GetFiltroParams();
    }
}
