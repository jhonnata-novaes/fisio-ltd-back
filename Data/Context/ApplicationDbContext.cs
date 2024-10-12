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
        public DbSet<FichaAnamnese> FichasAnamnese { get; set; }
        public DbSet<Exames> Exames { get; set; }
        public DbSet<DiagnosticoPrognostico> DiagnosticoPrognostico { get; set; }
        public DbSet<TratamentoProposto> TratamentoProposto { get; set; }
        
    }
}
