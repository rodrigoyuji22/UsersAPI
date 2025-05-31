using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task Cadastra(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var resultado = await _userManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário");
            }
            
        }
    }
}
