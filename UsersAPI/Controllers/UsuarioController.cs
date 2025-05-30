using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioController(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
    {
        var usuario = _mapper.Map<Usuario>(dto);
        var resultado = await _userManager.CreateAsync(usuario, dto.Password);
        if (resultado.Succeeded)
        {
            return Ok("Usuario cadastrado!");
        }
        throw new ApplicationException("Falha ao cadastrar usuário");
    }
}
