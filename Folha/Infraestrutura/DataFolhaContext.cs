using Folha.Models;
using Microsoft.EntityFrameworkCore;

namespace Folha.Infraestrutura
{
    public class DataFolhaContext : DbContext
    {
        public DataFolhaContext(DbContextOptions<DataFolhaContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        //protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) 
        //{
        //    IConfiguration configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json", false, true)
        //    .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataFolhaConnection")); 
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Funcionario>()
                .HasIndex(x => x.Documento)
                .IsUnique();

        }
    }
}
