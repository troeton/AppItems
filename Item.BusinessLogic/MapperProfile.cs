using AutoMapper;
using Item.BusinessLogic.Models;
using ItemDAO = Item.DataAccess.Models.Item;
using ItemDTO = Item.BusinessLogic.Models.Item;


namespace Item.BusinessLogic
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ItemDAO, ItemDTO>();
            CreateMap<ItemDTO, ItemDAO>();
            CreateMap<ItemDAO, ItemCreate>();
            CreateMap<ItemCreate, ItemDAO>();
        }
    }
}
