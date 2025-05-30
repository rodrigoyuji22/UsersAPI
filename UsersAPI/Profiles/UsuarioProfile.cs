using AutoMapper;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}
