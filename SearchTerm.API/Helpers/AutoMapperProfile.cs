using SearchTerm.API.Entities;
using SearchTerm.API.Requests.Model;
using AutoMapper;

namespace SearchTerm.API.Helpers
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CreateUserRequest, User>();
        }
    }
}
