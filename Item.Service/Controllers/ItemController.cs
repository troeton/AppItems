using Infraestructure.Common;
using Infraestructure.Models;
using Item.BusinessLogic.ItemService;
using Item.BusinessLogic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ItemDTO = Item.BusinessLogic.Models.Item;

namespace Item.Service.Controllers
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

        [HttpPost]
        public async Task<ActionResult<Response<ItemDTO>>> Create(Request<ItemCreate> item)
        {
            return Evaluate(await itemService.Create(item.Body));
        }

        [HttpPut]
        public async Task<ActionResult<Response<ItemDTO>>> Update(Request<ItemDTO> item)
        {
            return Evaluate(await itemService.Update(item.Body));
        }

        [HttpDelete]
        public async Task<ActionResult<Response<ItemDTO>>> Delete([FromQuery] int id)
        {
            return Evaluate(await itemService.Delete(id));
        }
    }
}
