using Microsoft.EntityFrameworkCore;

namespace fisio_ltd_back.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DadosBasicos> DadosBasicos { get; set; }
        // Adicione outros DbSets conforme necessário
    }
}
