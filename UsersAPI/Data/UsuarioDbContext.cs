using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data;

public class UsuarioDbContext : IdentityDbContext<Usuario>
{
    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts)
    {
        
    }
}
