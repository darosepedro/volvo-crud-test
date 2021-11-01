using Microsoft.EntityFrameworkCore;
using VolvoCrudApi.Models;

namespace VolvoCrudApi
{
    public class VolvoContext: DbContext
    {

        //Para Mock
        public VolvoContext()
        { }

        public VolvoContext(DbContextOptions<VolvoContext> options) : base(options)
        { }

        public DbSet<Caminhao> Caminhoes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModeloEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CaminhaoEntityConfiguration());


            modelBuilder.Entity<Modelo>().HasData(new Modelo(1,"FH"), new Modelo(2,"FM"));
        }
    }
}

