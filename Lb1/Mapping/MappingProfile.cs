using AutoMapper;
using Lb1.DB.Entites.Bank;
using Lb1.DB.Entites.BankE.CreditE;
using Lb1.DB.Entites.ClientE;
using Lb1.Modeles.Citizenship;
using Lb1.Modeles.Client;
using Lb1.Modeles.Credit.CreditList;
using Lb1.Modeles.Credit.CreditPlane;
using Lb1.Modeles.Deposite.DepositList;
using Lb1.Modeles.Deposite.DepositPlane;
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

            CreateMap<CreditList, CreditListViewModel>().ReverseMap();
            CreateMap<CreditListPostModel, CreditList>();
            CreateMap<CreditListPutModel, CreditList>();

            CreateMap<CreditPlane, CreditPlaneViewModel>().ReverseMap();
            CreateMap<CreditPlanePostModel, CreditPlane>();
            CreateMap<CreditPlanePutModel, CreditPlane>();

            CreateMap<DepositList, DepositListViewModel>().ReverseMap();
            CreateMap<DepositListPostModel, DepositList>();
            CreateMap<DepositListPutModel, DepositList>();

            CreateMap<DepositPlane, DepositPlaneViewModel>().ReverseMap();
            CreateMap<DepositPlanePostModel, DepositPlane>();
            CreateMap<DepositPlanePutModel, DepositPlane>();
        }
    }
}
