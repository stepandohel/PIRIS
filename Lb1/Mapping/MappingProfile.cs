using AutoMapper;
using Lb1.DB.Entites;
using Lb1.Modeles.Citizenship;
using Lb1.Modeles.Client;
using Lb1.Modeles.MaritalStatus;
using Lb1.Modeles.Town;

namespace Lb1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<ClientPostModel, Client>();
            CreateMap<ClientPutModel, Client>();

            CreateMap<Town, TownViewModel>().ReverseMap();

            CreateMap<MaritalStatus, MaritalStatusViewModel>().ReverseMap();

            CreateMap<Citizenship, CitizenshipViewModel>().ReverseMap();
        }
    }
}
