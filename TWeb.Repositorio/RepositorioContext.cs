using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using TWeb.Modelo;

namespace TWeb.Repositorio
{
    public class RepositorioContext : DbContext
    {
        public RepositorioContext()
        { }

        public RepositorioContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Prefeitura> Prefeitura { get; set; }
        public DbSet<Documentos> Documentos { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

            builder.Entity<Prefeitura>().Map(m => m.ToTable("Prefeitura"));

            builder.Entity<Prefeitura>().HasRequired(a => a.Documentos)
                .WithMany()
                .HasForeignKey(u => u.DocumentosId);


            builder.Entity<Documentos>().Map(m => m.ToTable("Documentos"));
            //builder.Entity<Prefeitura>().Ignore(e => e.Prefeito);

            builder.Entity<Documentos>().HasKey(x => x.Id).Property(x => x.Id).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            builder.Entity<Usuario>().Map(m => m.ToTable("Usuario"));
        }
    }
}
