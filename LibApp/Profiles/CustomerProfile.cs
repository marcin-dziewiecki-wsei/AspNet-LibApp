using AutoMapper;
using LibApp.Domain.Dtos;
using LibApp.Domain.Models;

namespace LibApp.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
