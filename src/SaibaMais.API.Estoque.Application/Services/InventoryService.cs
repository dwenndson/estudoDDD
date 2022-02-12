namespace SaibaMais.API.Estoque.Application.Services
{
    using AutoMapper;
    using SaibaMais.API.Estoque.Application.Interfaces;
    using SaibaMais.API.Estoque.Application.ViewModels;
    using SaibaMais.API.Estoque.Domain.Entities;
    using SaibaMais.API.Estoque.Domain.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repo;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponseViewModel> GetVehicleDetails(string chassi)
        {
            return _mapper.Map<ApiResponseViewModel>(await _repo.GetVehicleDetails(chassi));
        }

        public async Task<List<Inventory>> GetInventory(FiltroEstoque filtroEstoque)
        {
            return _mapper.Map<List<Inventory>>(await _repo.GetInventory(filtroEstoque));
        }

        public async Task<List<DetailedInventory>> GetDetailedInventory(FiltroDetailedInventory filtroDetailed)
        {
            return _mapper.Map<List<DetailedInventory>>(await _repo.GetDetailedInventory(filtroDetailed));
        }

        public async Task<FiltrosParams> GetFiltroParams()
        {
            return _mapper.Map<FiltrosParams>(await _repo.GetFiltroParams());
        }
    }
}
