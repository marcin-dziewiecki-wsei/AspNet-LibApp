using AutoMapper;
using LibApp.Domain.Dtos;
using LibApp.Domain.Models;

namespace LibApp.Profiles
{
    public class MembershipTypeProfile : Profile
    {
        public MembershipTypeProfile()
        {
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}
