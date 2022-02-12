namespace SaibaMais.API.Estoque.Domain.Interfaces
{
    using SaibaMais.API.Estoque.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInventoryRepository
    {
        Task<ApiResponse> GetVehicleDetails(string chassi);
        Task<List<Inventory>> GetInventory(FiltroEstoque filtroEstoque);
        Task<List<DetailedInventory>> GetDetailedInventory(FiltroDetailedInventory filtroDetailed);
        Task<FiltrosParams> GetFiltroParams();

    }
}
