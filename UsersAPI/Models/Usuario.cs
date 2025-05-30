using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Models;

public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public Usuario() : base() 
    {

    }
}

