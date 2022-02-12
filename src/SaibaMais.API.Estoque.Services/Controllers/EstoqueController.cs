namespace SaibaMais.API.Estoque.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SaibaMais.API.Estoque.Application.Interfaces;
    using SaibaMais.API.Estoque.Application.ViewModels;
    using SaibaMais.API.Estoque.Domain.Entities;

    [Route("api/[controller]")]
    public class EstoqueController : BaseController
    {
        private readonly IInventoryService _serv;

        public EstoqueController(IInventoryService serv,
                                   INotificator notificator) : base(notificator)
        {
            _serv = serv;
        }

        [HttpGet("GetVehicleDetails/{chassi}")]
        public async Task<ActionResult<ApiResponseViewModel>> GetVehicleDetails(string chassi)
        {
            try
            {                
                var ret = await _serv.GetVehicleDetails(chassi);

                return CustomResponse(ret);
            }
            catch(Exception e)
            {
                NotificateError("An error has occured. Message: " + e.Message);
                return CustomResponse(e.Message);
            }
        }

        [HttpGet("GetInventory")]
        public IActionResult GetInventory([FromQuery]FiltroEstoque filtroEstoque)
        {
            return CustomResponse(_serv.GetInventory(filtroEstoque));
        }

        [HttpGet("GetDetailedInventory")]
        public IActionResult GetDetailedInventory([FromQuery]FiltroDetailedInventory filtroDetailed)
        {
            return new JsonResult(_serv.GetDetailedInventory(filtroDetailed));
        }

        [HttpGet("GetFiltroParams")]
        public IActionResult GetFiltroParams()
        {
            return new JsonResult(_serv.GetFiltroParams());
        }
    }
}
