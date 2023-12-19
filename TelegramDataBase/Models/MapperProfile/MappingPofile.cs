using AutoMapper;

namespace TelegramDataBase.Models.MapperProfile
{
    public class MappingPofile : Profile
    {
        public MappingPofile() 
        {
            CreateMap<ModelUser, User>().ReverseMap(); // Маппинг для для передачи информации из ModelUser in User
            CreateMap<ModelUser, ModelGetRefKey>().ReverseMap();
            CreateMap<ModelUser, ListRefKeyUser>().ReverseMap();
        }

    }
}
