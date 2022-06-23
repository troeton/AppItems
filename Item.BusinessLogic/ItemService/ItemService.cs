using AutoMapper;
using DataAccess.UnitOfWork;
using Infraestructure.Models;
using Item.BusinessLogic.Models;
using Microsoft.Extensions.Logging;
using ItemDAO = Item.DataAccess.Models.Item;
using ItemDTO = Item.BusinessLogic.Models.Item;

namespace Item.BusinessLogic.ItemService
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<ItemService> logger;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ItemService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Response<ItemDTO>> Create(ItemCreate item)
        {
            try
            {
                var itemDAO = mapper.Map<ItemDAO>(item);
                await unitOfWork.Repository<ItemDAO>().InsertAsync(itemDAO);
                await unitOfWork.SaveAync();

                return new()
                {
                    Body = mapper.Map<ItemDTO>(itemDAO)
                };
            }
            catch (Exception ex)
            {
                logger.LogError("{ex}", ex);
                return new() { Errors = new List<string>() { "ha ocurrido un error inesperado" } };
            }
        }

        public async Task<Response<ItemDTO>> Delete(int id)
        {
            try
            {
                var itemDAO = mapper.Map<ItemDAO>(await Get(id));
                if (itemDAO == null)
                {
                    return new() { Errors = new List<string>() { "El item no existe" } };
                }
                unitOfWork.Repository<ItemDAO>().Delete(itemDAO);
                await unitOfWork.SaveAync();

                return new()
                {
                    Body = mapper.Map<ItemDTO>(itemDAO)
                };
            }
            catch (Exception ex)
            {
                logger.LogError("{ex}", ex);
                return new() { Errors = new List<string>() { "ha ocurrido un error inesperado" } };
            }
        }

        public async Task<Response<ItemDTO>> Get(int id)
        {
            try
            {
                return new()
                {
                    Body = mapper.Map<ItemDTO>((await unitOfWork.Repository<ItemDAO>()
                    .GetAsync(x => x.Id == id)).FirstOrDefault())
                };
            }
            catch (Exception ex)
            {
                logger.LogError("{ex}", ex);
                return new() { Errors = new List<string>() { "ha ocurrido un error inesperado" } };
            }
        }

        public async Task<Response<IEnumerable<ItemDTO>>> GetList()
        {
            try
            {
                return new()
                {
                    Body = mapper.Map<IEnumerable<ItemDTO>>(await unitOfWork.Repository<ItemDAO>().GetAsync())
                };
            }
            catch (Exception ex)
            {
                logger.LogError("{ex}", ex);
                return new() { Errors = new List<string>() { "ha ocurrido un error inesperado" } };
            }
        }

        public async Task<Response<ItemDTO>> Update(ItemDTO item)
        {
            try
            {
                var itemDAO = mapper.Map<ItemDAO>(item);
                unitOfWork.Repository<ItemDAO>().Update(itemDAO);
                await unitOfWork.SaveAync();

                return new()
                {
                    Body = mapper.Map<ItemDTO>(itemDAO)
                };
            }
            catch (Exception ex)
            {
                logger.LogError("{ex}", ex);
                return new() { Errors = new List<string>() { "ha ocurrido un error inesperado" } };
            }
        }
    }
}
