using AutoMapper;
using igreja.Application.DTOs;
using igreja.Domain.Models;

namespace igreja.Application.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            // Mapeamento bidirecional entre Church e ChurchDto
            CreateMap<User, UserDto>().ReverseMap();

        }

    }
}
