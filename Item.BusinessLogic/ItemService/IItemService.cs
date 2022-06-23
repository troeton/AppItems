using Infraestructure.Models;
using Item.BusinessLogic.Models;
using ItemDTO = Item.BusinessLogic.Models.Item;

namespace Item.BusinessLogic.ItemService
{
    public interface IItemService
    {
        Task<Response<ItemDTO>> Create(ItemCreate item);
        Task<Response<ItemDTO>> Get(int id);
        Task<Response<IEnumerable<ItemDTO>>> GetList();
        Task<Response<ItemDTO>> Update(ItemDTO item);
        Task<Response<ItemDTO>> Delete(int id);
    }
}
