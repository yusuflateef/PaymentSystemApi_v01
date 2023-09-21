using AutoMapper;
using PaymentSystemApi_v01.Core;
using PaymentSystemApi_v01.DTO;
using PaymentSystemApi_v01.Services;

namespace PaymentSystemApi_v01
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerRequest>().ReverseMap();

            CreateMap<Marchant, MarchantDto>().ReverseMap();
            CreateMap<TransactionHistory, TransactionHistoryDto>().ReverseMap();



        }
    }
}
