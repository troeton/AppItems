using Infraestructure.Common;
using Infraestructure.Models;
using Item.BusinessLogic.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ItemDTO = Item.BusinessLogic.Models.Item;

namespace ItemServiceRead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : CustomController
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<Response<ItemDTO>>> Get([FromQuery] int id)
        {
            return Evaluate(await itemService.Get(id));
        }

        [HttpGet("list")]
        public async Task<ActionResult<Response<IEnumerable<ItemDTO>>>> GetList()
        {
            return Evaluate(await itemService.GetList());
        }
    }
}
