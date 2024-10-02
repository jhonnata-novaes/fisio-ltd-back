using Microsoft.EntityFrameworkCore;

namespace fisio_ltd_back.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define a entidade/tabela do banco de dados
        public DbSet<DadosBasicos> DadosBasicos { get; set; }
    }
}
