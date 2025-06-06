﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task Cadastra(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var resultado = await _userManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded)
            {
                var erros = string.Join(", ", resultado.Errors.Select(e => e.Description));
                throw new ApplicationException($"Falha ao cadastrar usuário: {erros}");
            }
            
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado");
            }
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());
            var token = _tokenService.GenerateToken(usuario);
            return token;
        }
    }
}
