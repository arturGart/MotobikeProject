using Microsoft.AspNetCore.Mvc;
using Motobike.BusinessLogic.Services.Interface;
using Motobike.BusinessLogic.ViewModels.Request;
using System.Threading.Tasks;

namespace Motobike.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Order([FromBody]OrderRequest order)
        {
            await _orderService.Order(order);
            return Ok();
        }
    }
}