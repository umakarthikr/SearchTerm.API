using SearchTerm.API.Entities;
using SearchTerm.API.Requests.Model;
using AutoMapper;

namespace SearchTerm.API.Helpers
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.First_Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Last_Name));
        }
    }
}
