using AutoMapper;
using User.API.Entities;
using User.API.Models;

namespace User.API.Helpers
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            CreateMap<UsersRequestDto,Users>();
            CreateMap<AccountsRequestDto, Accounts>();
            CreateMap<Users, UsersResponseDto>();
            CreateMap<Accounts, AccountsResponseDto>();
        }        
    }
}
