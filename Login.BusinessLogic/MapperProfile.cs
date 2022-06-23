using AutoMapper;
using Login.BusinessLogic.Models;
using UserDAO = Login.DataAccess.Models.User;

namespace Login.BusinessLogic
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDAO, User>();
        }
    }
}
