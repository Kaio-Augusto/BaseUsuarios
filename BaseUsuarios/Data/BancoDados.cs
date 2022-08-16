using BaseUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseUsuarios.Data
{
    public class BancoDados : DbContext 
    {
        public BancoDados(DbContextOptions<BancoDados> options) : base(options) 
        { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
